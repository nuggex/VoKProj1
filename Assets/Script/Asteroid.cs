using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour
{
    public GameObject rocketShip;

    Transform newParent;
    float astspeed = 0.03f;

    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    Vector2 rocketTemp;
    Counters ast1 = new Counters();
    Counters ast2 = new Counters();
    Counters ast3 = new Counters();
    Counters rocket = new Counters();


    public Counters playingField(GameObject obj, Counters ast)
    {

        if (obj.transform.position.x <= -9 && ast.xLeft == 0) ast.xLeft++;
        else if (ast.xLeft != 0 && ast.xLeft <= 20) ast.xLeft++;
        else ast.xLeft = 0;
        if (obj.transform.position.x >= 9 && ast.xRight == 0) ast.xRight++;
        else if (ast.xRight != 0 && ast.xRight <= 20) ast.xRight++;
        else ast.xRight = 0;
        if (obj.transform.position.y <= -5 && ast.yLow == 0) ast.yLow++;
        else if (ast.yLow != 0 && ast.yLow <= 20) ast.yLow++;
        else ast.yLow = 0;
        if (obj.transform.position.y >= 5 && ast.yTop == 0) ast.yTop++;
        else if (ast.yTop != 0 && ast.yTop <= 20) ast.yTop++;
        else ast.yTop = 0;
        return ast;
    }
    public Counters distanceRocket(GameObject rocket, GameObject asteroid, Counters ast)
    {

        if (VArithmetics.GetDistance(rocket.transform.position, asteroid.transform.position) < 0.7f && ast.counter == 0)
        {
            ast.counter++;
            rocketTemp = rocket.transform.position;
        }
        if (ast.counter != 0 && ast.counter < 30)
        {
            ast.counter++;
            if (ast.counter >= 30) { ast.counter = 0; }
        }
        return ast;
    }
    public Counters distanceAsteroid(GameObject temp1, GameObject temp2, Counters ast)
    {

        if (VArithmetics.GetDistance(temp1.transform.position, temp2.transform.position) < 0.7f && ast.collision == 0)
        {
            temp1.transform.Translate(VArithmetics.GetVelocity(temp1.transform.position, temp2.transform.position, astspeed));
            temp2.transform.Translate(VArithmetics.GetVelocity(temp2.transform.position, temp1.transform.position, astspeed));
            ast.collision++;
        }
        if (ast.collision != 0 && ast.collision < 30)
        {
            temp1.transform.Translate(VArithmetics.GetVelocity(temp1.transform.position, temp2.transform.position, astspeed));
            temp2.transform.Translate(VArithmetics.GetVelocity(temp2.transform.position, temp1.transform.position, astspeed));
            ast.collision++;
            if (ast.collision >= 30) { ast.collision = 0; }
        }
        return ast;
    }
    public void move(GameObject obj, Counters ast)
    {
        if (ast.counter == 0) obj.transform.Translate(VArithmetics.GetVelocity(rocketShip.transform.position, obj.transform.position, astspeed));
        else if (ast.counter != 0 && ast.collision != 0) { }
        else if (ast.counter != 0 && ast.collision == 0) obj.transform.Translate(VArithmetics.GetVelocity(obj.transform.position, rocketTemp, astspeed));
    }

    void Start()
    {

    }
    void Update()
    {
        rocketShip.transform.SetParent(newParent);
        //checks if objects inside playingfield
        rocket = playingField(rocketShip, rocket);
        ast1 = playingField(asteroid1, ast1);
        ast2 = playingField(asteroid2, ast2);
        ast3 = playingField(asteroid3, ast3);

        //test collisions between asteroids and moves them
        ast1 = distanceAsteroid(asteroid1, asteroid2, ast1);
        ast2 = distanceAsteroid(asteroid2, asteroid3, ast2);
        ast3 = distanceAsteroid(asteroid3, asteroid1, ast3);

        //Tests distance between asteroid and rocket
        ast1 = distanceRocket(rocketShip, asteroid1, ast1);
        ast2 = distanceRocket(rocketShip, asteroid2, ast2);
        ast3 = distanceRocket(rocketShip, asteroid3, ast3);

        //moves asteroids

        move(asteroid1, ast1);
        move(asteroid2, ast2);
        move(asteroid3, ast3);
    }
}