using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    
    public GameObject rocketShip;
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
        if (distance > minDistance)
        {
            transform.Translate(var.GetVelocity(rocketShip.transform.position, transform.position, aspeed));
        }

    }
}

