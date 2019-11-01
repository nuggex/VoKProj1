using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocket : MonoBehaviour
{
    public float movementspeed = 1f;
    public float x;
    public float y;
    public AudioSource audioData;



    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        audioData = GetComponent<AudioSource>();
        Vector2 v = new Vector2(0.1f, 0);
        // Vector2 h = new Vector2(0, 0.1f);

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

        if (Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false)
        {
            audioData.Stop();
        }
            if (Input.GetKey(KeyCode.RightArrow) == true && Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false )
        {
            transform.Translate(v);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (!audioData.isPlaying)
            {
                audioData.Play();
            }
            
            
        }
        if (Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.UpArrow) == true && Input.GetKey(KeyCode.DownArrow) == false)
        {
            transform.Translate(v);
            transform.rotation = Quaternion.Euler(0, 0, 90);
            if (!audioData.isPlaying)
            {
                audioData.Play();
            }
        }
      
        if (Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.LeftArrow) == true && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false)
        {
            transform.Translate(v);
            transform.rotation = Quaternion.Euler(0, 0, 180);
            if (!audioData.isPlaying)
            {
                audioData.Play();
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == true)
        {
            transform.Translate(v);
            transform.rotation = Quaternion.Euler(0, 0, 270);
            if (!audioData.isPlaying)
            {
                audioData.Play();
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) == true && Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.UpArrow) == true && Input.GetKey(KeyCode.DownArrow) == false)
        {
            transform.Translate(v);
            transform.rotation = Quaternion.Euler(0, 0, 45);
            if (!audioData.isPlaying)
            {
                audioData.Play();
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.LeftArrow) == true && Input.GetKey(KeyCode.UpArrow) == true && Input.GetKey(KeyCode.DownArrow) == false)
        {
            transform.Translate(v);
            transform.rotation = Quaternion.Euler(0, 0, 135);
            if (!audioData.isPlaying)
            {
                audioData.Play();
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.LeftArrow) == true && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == true)
        {
            transform.Translate(v);
            transform.rotation = Quaternion.Euler(0, 0, 225);
            if (!audioData.isPlaying)
            {
                audioData.Play();
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) == true && Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == true)
        {
            transform.Translate(v);
            transform.rotation = Quaternion.Euler(0, 0, 315);
            if (!audioData.isPlaying)
            {
                audioData.Play();
            }
        }
    }
}