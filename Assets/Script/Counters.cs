using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counters
{


    public bool yOutOfBounds { get; set; }
    public bool xOutOfBounds { get; set; }
    public bool collisionBool { get; set; }
    public Vector2 objectTemp { get; set; }
    public Vector2 collisionTemp { get; set; }
    public Vector2 previousFrame { get; set; }
    public int counter { get; set; }


}