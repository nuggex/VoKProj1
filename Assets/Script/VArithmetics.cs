using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VArithmetics : MonoBehaviour
{


    float GetDistance(Vector2 v1, Vector2 v2)
    {
        float x = v1.x - v2.x;
        float y = v1.y - v2.y;
        return (Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2)));
    }
    public Vector2 GetDirection(Vector2 v1, Vector2 v2)
    {

        Vector2 temp = new Vector2(v1.x - v2.x, v1.y - v2.y);
        return temp;
    }

        
 
    public Vector2 GetNormalized(Vector2 v)
    {
        float magnitude = Mathf.Sqrt(Mathf.Pow(v.x, 2) + Mathf.Pow(v.y, 2));
        Vector2 temp = new Vector2(v.x / magnitude, v.y / magnitude);
        return temp;
    }

    
    public Vector2 GetVelocity(Vector2 v1, Vector2 v2, float speed)
    {
        
        Vector2 direction;
        direction = GetDirection(v1, v2);
        Vector2 unitDirection;
        unitDirection = GetNormalized(direction);
        Vector2 Velo = new Vector2(unitDirection.x * speed, unitDirection.y * speed);
        return Velo;
    }

    void Start()
    {

      

    }
    void Update()
    {
        float speed = 0.1f;
        Vector2 v1 = new Vector2(-2.0f, 5.0f);
        Vector2 v2 = new Vector2(-6.0f, 10.0f);
    }
}
