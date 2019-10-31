using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocket : MonoBehaviour
{
    public float movementspeed = 1f;
    public float x;
    public float y;

    AsteroidMove am = new AsteroidMove();
    

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 v = new Vector2(0.1f,0);
        Vector2 h = new Vector2(0, 0.1f);

        //transform.position =  new Vector2(transform.position.x + v.x, transform.position.y + 0);


        //Adderar positionsvektorn med vektorn v. NYa positionsvektorn blir då resultanten av vektoraddition. 
        //transform.Translate(v);
        
        
        // get the input from horizontal axis // 
       // float horizontalInput = Input.GetAxis("Horizontal");
        // get the input from the vertical axis // 
        //float verticalInput = Input.GetAxis("Vertical");

        // Jonnys Metod 

        /*
        if(Input.GetKey(KeyCode.RightArrow) == true){
        v = new Vector2(0.05f, v.y);
        }
         if(Input.GetKey(KeyCode.LeftArrow) == true){
        v = new Vector2(-0.05f, v.y);
        }
         if(Input.GetKey(KeyCode.UpArrow) == true){
        v = new Vector2(v.x, 0.05f);
        }
        if(Input.GetKey(KeyCode.DownArrow) == true){
        v = new Vector2(v.x, -0.05f);
        }

        transform.Translate(v);
        */


        if (Input.GetKey("left"))
        {
            transform.Translate(-v/2);
           // transform.position = transform.position + new Vector3(horizontalInput * movementspeed * Time.deltaTime, verticalInput *movementspeed * Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(v);
           // transform.position = transform.position + new Vector3(horizontalInput * movementspeed * Time.deltaTime, verticalInput * movementspeed * Time.deltaTime);
        }
        if (Input.GetKey("up"))
        {
            transform.Translate(h);
            //transform.position = transform.position + new Vector3(horizontalInput * movementspeed * Time.deltaTime, verticalInput * movementspeed * Time.deltaTime);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(-h);
            //transform.position = transform.position + new Vector3(horizontalInput * movementspeed * Time.deltaTime, verticalInput * movementspeed * Time.deltaTime);
        }
    }   
}
