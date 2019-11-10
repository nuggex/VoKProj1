using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VArithmetics
{



    public static float GetDistance(Vector2 v1, Vector2 v2)
    {
        Vector2 D = v2 - v1;
        return (Mathf.Sqrt(Mathf.Pow(D.x, 2) + Mathf.Pow(D.y, 2)));
    }
    public static Vector2 GetDirection(Vector2 v1, Vector2 v2)
    {

        Vector2 temp = new Vector2(v1.x - v2.x, v1.y - v2.y);
        return temp;
    }



    public static Vector2 GetNormalized(Vector2 v)
    {
        float magnitude = Mathf.Sqrt(Mathf.Pow(v.x, 2) + Mathf.Pow(v.y, 2));
        Vector2 temp = new Vector2(v.x / magnitude, v.y / magnitude);
        return temp;
    }


    public static Vector2 GetVelocity(Vector2 v1, Vector2 v2, float speed, Counters ast)
    {
        float speedier = speed * 1.5f;
        Vector2 velo;
        Vector2 direction;
        direction = GetDirection(v1, v2);
        Vector2 unitDirection;
        unitDirection = GetNormalized(direction);
        if (ast.collisionBool) velo = new Vector2(unitDirection.x * (speedier), unitDirection.y * (speedier)); //attempt to make asteroids bounce more
        else velo = new Vector2(unitDirection.x * speed, unitDirection.y * speed);
        return velo;
    }


}