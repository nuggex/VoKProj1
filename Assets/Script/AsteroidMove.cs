using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    
    public GameObject rocketShip;
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public GameObject asteroid4; 


    float aspeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float minDistance = 1.1f;
        VArithmetics var = new VArithmetics();
        float distance = var.GetDistance(transform.position, rocketShip.transform.position);
        float distanceA12 = var.GetDistance(asteroid1.transform.position, asteroid2.transform.position);
        float distanceA13 = var.GetDistance(asteroid1.transform.position, asteroid3.transform.position);
        float distanceA14 = var.GetDistance(asteroid1.transform.position, asteroid4.transform.position);
        float distanceA23 = var.GetDistance(asteroid2.transform.position, asteroid3.transform.position);
        float distanceA24 = var.GetDistance(asteroid2.transform.position, asteroid4.transform.position);
        float distanceA34 = var.GetDistance(asteroid3.transform.position, asteroid4.transform.position);

        if (distanceA12 <= minDistance)
        {
          transform.Translate(var.GetVelocity(transform.position, asteroid2.transform.position, aspeed));
        }
   
        if (distanceA13 <= minDistance)
        {
            transform.Translate(var.GetVelocity(transform.position, asteroid3.transform.position, aspeed));
        }
 
        if (distanceA14 <= minDistance)
        {
            transform.Translate(var.GetVelocity(transform.position, asteroid4.transform.position, aspeed));
        }

        if (distanceA23 <= minDistance)
        {
            transform.Translate(var.GetVelocity(transform.position, asteroid3.transform.position, aspeed));
        }

        if (distanceA24 <= minDistance)
        {
            transform.Translate(var.GetVelocity(transform.position, asteroid4.transform.position, aspeed));
        }
      
        if (distanceA34 <= minDistance)
        {
            transform.Translate(var.GetVelocity(transform.position, asteroid4.transform.position, aspeed));
        }
        
        if (distance > minDistance)
        {
            transform.Translate(var.GetVelocity(rocketShip.transform.position, transform.position, aspeed));
        }
        if(distance < minDistance)
        {
            transform.Translate(var.GetVelocity(transform.position, rocketShip.transform.position, aspeed));
        }

    }
}

