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
    Transform newParent;

    float aspeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {

        rocketShip.transform.SetParent(newParent);
        float minDistance = 1.1f;   
        float distance = VArithmetics.GetDistance(transform.position, rocketShip.transform.position);
        float distanceA12 = VArithmetics.GetDistance(asteroid1.transform.position, asteroid2.transform.position);
        float distanceA13 = VArithmetics.GetDistance(asteroid1.transform.position, asteroid3.transform.position);
        float distanceA14 = VArithmetics.GetDistance(asteroid1.transform.position, asteroid4.transform.position);
        float distanceA23 = VArithmetics.GetDistance(asteroid2.transform.position, asteroid3.transform.position);
        float distanceA24 = VArithmetics.GetDistance(asteroid2.transform.position, asteroid4.transform.position);
        float distanceA34 = VArithmetics.GetDistance(asteroid3.transform.position, asteroid4.transform.position);

        if (distanceA12 <= minDistance)
        {
            if (transform.position == asteroid1.transform.position)
            {
                return;
            }
            asteroid1.transform.Translate(VArithmetics.GetVelocity(transform.position, asteroid1.transform.position, aspeed));
            asteroid2.transform.Translate(VArithmetics.GetVelocity( asteroid1.transform.position, transform.position, aspeed));

        }

        if (distanceA13 <= minDistance)
        {
            if (transform.position == asteroid3.transform.position)
            {
                return;
            }
            asteroid1.transform.Translate(VArithmetics.GetVelocity(transform.position, asteroid3.transform.position, aspeed));
            asteroid3.transform.Translate(VArithmetics.GetVelocity(transform.position, asteroid3.transform.position, aspeed));
        }

        if (distanceA14 <= minDistance)
        {
            if (transform.position == asteroid4.transform.position)
            {
                return;
            }
            asteroid1.transform.Translate(VArithmetics.GetVelocity(transform.position, asteroid4.transform.position, aspeed));
            asteroid4.transform.Translate(VArithmetics.GetVelocity( asteroid4.transform.position, transform.position, aspeed));
        }

        if (distanceA23 <= minDistance)
        {
            if (transform.position == asteroid3.transform.position)
            {
                return;
            }
            asteroid2.transform.Translate(VArithmetics.GetVelocity(transform.position, asteroid3.transform.position, aspeed));
            asteroid3.transform.Translate(VArithmetics.GetVelocity(asteroid3.transform.position, transform.position, aspeed));
        }

        if (distanceA24 <= minDistance)
        {
            if (transform.position == asteroid4.transform.position)
            {
                return;
            }
            asteroid2.transform.Translate(VArithmetics.GetVelocity(transform.position, asteroid4.transform.position, aspeed));
            asteroid4.transform.Translate(VArithmetics.GetVelocity(asteroid4.transform.position, transform.position, aspeed));

        }

        if (distanceA34 <= minDistance)
        {
            if (transform.position == asteroid4.transform.position)
            {
                return;
            }
            asteroid3.transform.Translate(VArithmetics.GetVelocity(transform.position, asteroid4.transform.position, aspeed));
            asteroid4.transform.Translate(VArithmetics.GetVelocity(asteroid4.transform.position, transform.position, aspeed));

        }

        if ((distance - minDistance) < 0.1)
        {
            return;
        }
        else { 
        if (distance > minDistance)
        {
            transform.Translate(VArithmetics.GetVelocity(rocketShip.transform.position, transform.position, aspeed));
        }
        
        if (distance < minDistance)
        {
            transform.Translate(VArithmetics.GetVelocity(transform.position, rocketShip.transform.position, aspeed));
        }
        }
    }
}
