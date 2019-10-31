using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{

    public class rocketPosition
    {
        public Vector2 pos;

        public rocketPosition(Vector2 p)
        {
            pos = p;
        }
    }
   
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rocketPosition rp = new rocketPosition();
        Debug.Log(rocketPosition.p.x);
    }
}

