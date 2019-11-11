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
    public GameObject asteroid4;

    Counters ast1 = new Counters();
    Counters ast2 = new Counters();
    Counters ast3 = new Counters();
    Counters ast4 = new Counters();
    Counters rocket = new Counters();
    //counterVal set the distance asteroids travel after collision
    private int counterVal = 80;
    private double astDistVal = 0.8f;
    float astspeed = 0.07f;

    public void collisionFunction(Counters ast)
    {
        ast.collisionBool = true;
        ast.counter = 0;
    }
    public void testBoolean(Counters ast)
    {
        Debug.Log("Counter is: " + ast.counter + " Boolean is: " + ast.collisionBool);
        //test how long since last collision
        if (ast.counter >= counterVal)
        {
            ast.collisionBool = false;
            ast.counter = 0;
        }
        else if (ast.counter <= counterVal)
        {
            ast.counter++;
        }
    }
    public void playingField(GameObject obj, Counters ast)
    {

        var value = 0.1f;
        // if object outside of playing field Stores the point of collision with border - value so to not get NaN when calculating velocity 
        if (obj.transform.position.x <= -9)
        {
            Vector2 temp = new Vector2((ast.previousFrame.x - value), ast.previousFrame.y);
            ast.collisionTemp = temp;
        }
        if (obj.transform.position.x >= 9)
        {
            Vector2 temp = new Vector2((ast.previousFrame.x + value), ast.previousFrame.y);
            ast.collisionTemp = temp;
        }
        if (obj.transform.position.y <= -5)
        {
            Vector2 temp = new Vector2(ast.previousFrame.x, (ast.previousFrame.y - value));
            ast.collisionTemp = temp;
        }
        if (obj.transform.position.y >= 5)
        {
            Vector2 temp = new Vector2(ast.previousFrame.x, (ast.previousFrame.y + value));
            ast.collisionTemp = temp;
        }
    }

    public void detectCollision(Counters ast)
    {

        // temporary Vector2 variables
        Vector2 ast1Vec = asteroid1.transform.position;
        Vector2 ast2Vec = asteroid2.transform.position;
        Vector2 ast3Vec = asteroid3.transform.position;
        Vector2 ast4Vec = asteroid4.transform.position;

        //tests distance between asteroid and rocket
        if (VArithmetics.GetDistance(rocketShip.transform.position, ast.objectTemp) <= 0.75f)
        {
            collisionFunction(ast);
            ast.collisionTemp = rocketShip.transform.position;
        }

        //test distance between asteroids
        if (ast.objectTemp != ast1Vec && VArithmetics.GetDistance(ast.objectTemp, ast1Vec) < astDistVal)
        {
            collisionFunction(ast);
            ast.collisionTemp = ast1Vec;
        }
        if (ast.objectTemp != ast2Vec && VArithmetics.GetDistance(ast.objectTemp, ast2Vec) < astDistVal)
        {
            collisionFunction(ast);
            ast.collisionTemp = ast2Vec;
        }
        if (ast.objectTemp != ast3Vec && VArithmetics.GetDistance(ast.objectTemp, ast3Vec) < astDistVal)
        {
            collisionFunction(ast);
            ast.collisionTemp = ast3Vec;
        }
        if (ast.objectTemp != ast4Vec && VArithmetics.GetDistance(ast.objectTemp, ast4Vec) < astDistVal)
        {
            collisionFunction(ast);
            ast.collisionTemp = ast4Vec;
        }
    }
    public void move(GameObject obj, Counters ast)
    {
        if (ast.collisionBool) obj.transform.Translate(VArithmetics.GetVelocity(obj.transform.position, ast.collisionTemp, astspeed, ast));
        else if (!ast.collisionBool) obj.transform.Translate(VArithmetics.GetVelocity(rocketShip.transform.position, obj.transform.position, astspeed, ast));

        //stores new position
        ast.previousFrame = obj.transform.position;
        ast.objectTemp = obj.transform.position;
    }

    void Start()
    {

    }
    void Update()
    {

        rocketShip.transform.SetParent(newParent);

        //stores positions
        ast1.objectTemp = asteroid1.transform.position;
        ast2.objectTemp = asteroid2.transform.position;
        ast3.objectTemp = asteroid3.transform.position;
        ast4.objectTemp = asteroid4.transform.position;

        //checks time since last collision
        testBoolean(ast1);
        testBoolean(ast2);
        testBoolean(ast3);
        testBoolean(ast4);

        //checks if object is inside playingfield
        playingField(asteroid1, ast1);
        playingField(asteroid2, ast2);
        playingField(asteroid3, ast3);
        playingField(asteroid4, ast4);

        // Tests distances and detects collisions
        detectCollision(ast1);
        detectCollision(ast2);
        detectCollision(ast3);
        detectCollision(ast4);

        //moves asteroids
        move(asteroid1, ast1);
        move(asteroid2, ast2);
        move(asteroid3, ast3);
        move(asteroid4, ast4);

        // final test 
        testBoolean(ast1);
        testBoolean(ast2);
        testBoolean(ast3);
        testBoolean(ast4);
    }
}