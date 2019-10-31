using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{

    float aspeed = 0.05f;

    Vector2 rocketPosition;

    public void SetPosition(float x, float y)
    {
        Vector2 rp = new Vector2(x,y);
        rocketPosition = rp;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

        Debug.Log(rocketPosition);
    }
}

