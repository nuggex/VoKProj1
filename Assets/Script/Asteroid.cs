using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour
{
    Transform newParent;
    public GameObject rocketShip;
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
 
    Counters ast1 = new Counters();
    Counters ast2 = new Counters();
    Counters ast3 = new Counters();
    Counters rocket = new Counters();
    public int counterVal = 100;
    float astspeed = 0.05f;
    public AudioSource collission;

    public void testBoolean(GameObject obj, Counters ast)
    {
        if (ast.collisionBool)
        {
            ast.counter++;
        }
        //var value = 3f;
        //  if (VArithmetics.GetDistance(obj.transform.position, ast.collisionTemp) > value ){
        if (ast.counter >= counterVal)
        {
            ast.collisionBool = false;
        }
    }

    public void playingField(GameObject obj, Counters ast)
    {
        var value = 0.1f;
        // if object is inside playing field and distance from point of collision with border is > 1 units outOfBounds set to false
        if ((obj.transform.position.x >= -9 || obj.transform.position.x <= 9 || obj.transform.position.y >= -5 || obj.transform.position.y <= 5) && ast.counter >= counterVal)
        {
            ast.xOutOfBounds = false;
            ast.yOutOfBounds = false;
        }

        // if object outside of playing field OutOfBounds set to true. Stores the point of collision with border - a fixed value so to not get NaN when calculating velocity 
        if (obj.transform.position.x <= -9)
        {
            Vector2 temp = new Vector2((ast.previousFrame.x - value), ast.previousFrame.y);
            ast.collisionTemp = temp;
            ast.xOutOfBounds = true;
        }
        if (obj.transform.position.x >= 9)
        {
            Vector2 temp = new Vector2((ast.previousFrame.x + value), ast.previousFrame.y);
            ast.collisionTemp = temp;
            ast.yOutOfBounds = true;
        }
        if (obj.transform.position.y <= -5)
        {

            Vector2 temp = new Vector2(ast.previousFrame.x, (ast.previousFrame.y - value));
            ast.collisionTemp = temp;
            ast.yOutOfBounds = true;
        }
        if (obj.transform.position.y >= 5)
        {

            Vector2 temp = new Vector2(ast.previousFrame.x, (ast.previousFrame.y + value));
            ast.collisionTemp = temp;
            ast.yOutOfBounds = true;
        }
    }
    public void distanceRocket(Counters rocket, Counters ast)
    {


        if (VArithmetics.GetDistance(rocket.objectTemp, ast.objectTemp) < 0.7f)
        {
            if (!collission.isPlaying)
            {
                collission.Play();
            }

            if (ast.xOutOfBounds || ast.yOutOfBounds)
            {
                ast.xOutOfBounds = false;
                ast.yOutOfBounds = false;
            }
            //resets countdown timer everytime a collision is detected
            ast.counter = 0;
            ast.collisionBool = true;
            //stores point of collision
            ast.collisionTemp = rocket.objectTemp;
        }
    }


    public void distanceAsteroid(GameObject temp1, GameObject temp2, Counters ast, Counters ast2)
    {


        if (VArithmetics.GetDistance(ast.objectTemp, ast2.objectTemp) < 0.7f)
        {

            if (ast.xOutOfBounds || ast.yOutOfBounds)
            {
                ast.xOutOfBounds = false;
                ast.yOutOfBounds = false;
            }
            //resets countdown timer everytime a collision is detected
            ast.counter = 0;
            ast.collisionBool = true;
            ast2.collisionBool = true;

            //stores point of collision
            ast.collisionTemp = ast2.objectTemp;
            ast2.collisionTemp = ast.objectTemp;
       
        }


    }



    public void move(GameObject obj, Counters ast)
    {

        //if asteroid outofbounds travel away from collision point with border
        if (ast.xOutOfBounds || ast.yOutOfBounds) obj.transform.Translate(VArithmetics.GetVelocity(obj.transform.position, ast.collisionTemp, astspeed, ast));

        // if a collision has happened asteroid will travel away from collision point until counter reaches value from collision is true
        else if (ast.collisionBool)
        {
            obj.transform.Translate(VArithmetics.GetVelocity(obj.transform.position, ast.collisionTemp, astspeed, ast));

        }
        //When no condition is met asteroid travels towards Rocketship
        else obj.transform.Translate(VArithmetics.GetVelocity(rocketShip.transform.position, obj.transform.position, astspeed, ast));


    }

    void Start()
    {

    }
    void Update()
    {

        rocketShip.transform.SetParent(newParent);
        rocket.objectTemp = rocketShip.transform.position;
        ast1.objectTemp = asteroid1.transform.position;
        ast2.objectTemp = asteroid2.transform.position;
        ast3.objectTemp = asteroid3.transform.position;

        //checks distance from last collision
        testBoolean(asteroid1, ast1);
        testBoolean(asteroid2, ast2);
        testBoolean(asteroid3, ast3);

        //checks if object is inside playingfield
        //rocket = playingField(rocketShip, rocket);
        playingField(asteroid1, ast1);
        playingField(asteroid2, ast2);
        playingField(asteroid3, ast3);

        // detects collisions between asteroid and rocket 
        distanceRocket(rocket, ast1);
        distanceRocket(rocket, ast2);
        distanceRocket(rocket, ast3);

        // detects collisions between asteroids
        distanceAsteroid(asteroid1, asteroid2, ast1, ast2);
        distanceAsteroid(asteroid2, asteroid3, ast2, ast3);
        distanceAsteroid(asteroid3, asteroid1, ast3, ast1);

        //extra tests just to be sure
        testBoolean(asteroid1, ast1);
        testBoolean(asteroid2, ast2);
        testBoolean(asteroid3, ast3);

        //moves asteroids

        move(asteroid1, ast1);
        move(asteroid2, ast2);
        move(asteroid3, ast3);

        //and one final test juust to be extra sure
        testBoolean(asteroid1, ast1);
        testBoolean(asteroid2, ast2);
        testBoolean(asteroid3, ast3);

        Debug.Log("ast1 collision: " + ast1.collisionBool);
        Debug.Log("ast2 collision: " + ast2.collisionBool);
        //Debug.Log("ast3 collision: " +ast3.collisionBool);
        Debug.Log("ast1 collision temp: " + ast1.collisionTemp);
        Debug.Log("ast2 collision temp: " + ast2.collisionTemp);
        //Debug.Log("ast3 collision temp: " +ast3.collisionTemp);

        //stores position of asteroids at end of frame
        ast1.previousFrame = asteroid1.transform.position;
        ast2.previousFrame = asteroid2.transform.position;
        ast3.previousFrame = asteroid3.transform.position;



    }
}