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
        float astDistance = 1.5f;
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
            if (transform.position == asteroid1.transform.position)
            {
                return;
            }
            transform.Translate(var.GetVelocity(transform.position, asteroid1.transform.position, aspeed));
        }
        Debug.Log("Distance12: " + distanceA12);
        Debug.Log("Transform.position: " + transform.position);
        Debug.Log("Trans.pos asteroid1: " + asteroid1.transform.position);
        Debug.Log("Trans.pos asteroid2: " + asteroid2.transform.position);
        if (distanceA13 <= minDistance)
        {
            if (transform.position == asteroid3.transform.position)
            {
                return;
            }
            transform.Translate(var.GetVelocity(transform.position, asteroid3.transform.position, aspeed));
        }

        if (distanceA14 <= minDistance)
        {
            if (transform.position == asteroid4.transform.position)
            {
                return;
            }
            transform.Translate(var.GetVelocity(transform.position, asteroid4.transform.position, aspeed));
        }

        if (distanceA23 <= minDistance)
        {
            if (transform.position == asteroid3.transform.position)
            {
                return;
            }
            transform.Translate(var.GetVelocity(transform.position, asteroid3.transform.position, aspeed));
        }

        if (distanceA24 <= minDistance)
        {
            if (transform.position == asteroid4.transform.position)
            {
                return;
            }
            transform.Translate(var.GetVelocity(transform.position, asteroid4.transform.position, aspeed));
        }

        if (distanceA34 <= minDistance)
        {
            if (transform.position == asteroid4.transform.position)
            {
                return;
            }
            transform.Translate(var.GetVelocity(transform.position, asteroid4.transform.position, aspeed));
        }

        if (distance > minDistance)
        {
            transform.Translate(var.GetVelocity(rocketShip.transform.position, transform.position, aspeed));
        }
        if (distance < minDistance)
        {
            transform.Translate(var.GetVelocity(transform.position, rocketShip.transform.position, aspeed));
        }

    }
}
