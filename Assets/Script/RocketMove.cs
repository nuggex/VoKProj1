using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    public float speedare;
    public float reversespeed;
    public float movementspeed;
    public float z;
    public AudioSource forward;
    public AudioSource reverse;
    void Start()
    {
        reversespeed = 0.7f;
        speedare = 360f;
    }
    void FixedUpdate()
    {
        // hastighet för svängning deklareras här // 
        float rotspeed = speedare * Time.fixedDeltaTime;
        // Vector för att flytta på skeppet i riktning av det // 
        Vector2 v = new Vector2(movementspeed, 0);
        // Accelerera skeppet mot max hastighet // 
        if (Input.GetKey(KeyCode.DownArrow) == false && Input.GetKey(KeyCode.UpArrow) == true)
        {
            if (movementspeed < 0.15f)
            {
                movementspeed = movementspeed + 0.01f;
            }
            if (!forward.isPlaying)
            {
                forward.Play();
            }
        }
        // Accellerera skeppet mot max hastighet bakåt // 
        if (Input.GetKey(KeyCode.DownArrow) == true && Input.GetKey(KeyCode.UpArrow) == false)
        {
            if (movementspeed > -0.10f)
            {
                movementspeed = movementspeed - 0.01f;
            }
            if (!reverse.isPlaying)
            {
                reverse.Play();
            }
        }
        // Deaccelerar skäppet mot noll ifall varken upp eller ner hålls tryckt hålls uppe. // 
        if (Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false)
        {
            /*  audioData.Stop();*/
            if (movementspeed >= 0.01f)
            {
                movementspeed = movementspeed - 0.005f;
                transform.Translate(v);
            }
            if (movementspeed <= -0.01f)
            {
                movementspeed = movementspeed + 0.005f;
                transform.Translate(v);
            }
        }
        // rotera skäppet till höger runt skäppets Z axel  // 
        if (Input.GetKey(KeyCode.RightArrow) == true && Input.GetKey(KeyCode.LeftArrow) == false)
        {
            transform.Rotate(0, 0, -rotspeed, Space.Self);
        }
        // rotera skäppet till vänster runt skäppets Z axel // 
        if (Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.LeftArrow) == true)
        {
            transform.Rotate(0, 0, rotspeed, Space.Self);
        }
        // Flytta skeppet frammåt i dess Z riktning // 
        if (Input.GetKey(KeyCode.UpArrow) == true && Input.GetKey(KeyCode.DownArrow) == false)
        {
            transform.Translate(v);
        }
        // Flytta skeppet backåt i förhållande till dess Z riktning // 
        if (Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == true)
        {
            transform.Translate(v * reversespeed);
        }
        // Refleketera skeppet i inversa vinkeln på X axelns gränser // 
        if (transform.position.x >= 9 || transform.position.x <= -9)
        {
            z = transform.eulerAngles.z;
            if (z < 0)
            {
                z = -180 - z;
            }
            if (z >= 0)
            {
                z = 180 - z;
            }
            transform.localRotation = Quaternion.Euler(0, 0, z);
        }
        // Reflektera skäppet i inversa vinkeln på Y Axelns gränser // 
        if (transform.position.y >= 5f || transform.position.y <= -5f)
        {
            transform.rotation = Quaternion.Inverse(transform.rotation);
        }
    }
}
