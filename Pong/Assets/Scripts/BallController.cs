
using System.Collections.Generic;
using System.Security.Cryptography;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    // public Vector3 movement;
    public Transform myTransform;
    public float movementX;
    public float movementZ;
    public float speed = 1.000f;
    public TextMeshProUGUI LeftScore;
    public TextMeshProUGUI RightScore;
    public int LeftScoreCount;
    public int RightScoreCount;
    public bool startside;
    public int startangle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        LeftScoreCount = 0;
        RightScoreCount = 0;
        SetCountText();
        myTransform = GetComponent<Transform>();
        startside = UnityEngine.Random.value >= .5;
        if (startside == true)
        {
            movementX = -1f;
        } else
        {
            movementX = 1f;
        }

        movementZ = UnityEngine.Random.Range(-1f,1f);
        rb.linearVelocity = new Vector3(movementX * 8f * speed ,0f , movementZ * 8f * speed);
        
    }

    
    void FixedUpdate()
    {
        speed += .00001f;
        if (Keyboard.current.fKey.isPressed)
             rb.MovePosition(rb.position - Vector3.right * 3f * Time.deltaTime * speed);

        if (Keyboard.current.hKey.isPressed)
            rb.MovePosition(rb.position - Vector3.left * 3f * Time.deltaTime * speed);

        if (Keyboard.current.tKey.isPressed)
             rb.MovePosition(rb.position - Vector3.back * 3f * Time.deltaTime * speed);

        if (Keyboard.current.gKey.isPressed)
            rb.MovePosition(rb.position - Vector3.forward * 3f * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LeftGoal"))
        {
            Debug.Log("Left Hit");
            speed = 1.0f;
            RightScoreCount += 1;
            SetCountText();
            myTransform.position = new Vector3(5f, 0.5f, 0f);
            rb.linearVelocity = new Vector3(-12f * speed ,0f , UnityEngine.Random.Range(-1f,1f)* 12f * speed);

            

        }
       if (collision.gameObject.CompareTag("RightGoal"))
        {
            Debug.Log("Right Hit");
            speed = 1.0f;
            LeftScoreCount += 1;
            SetCountText();
            myTransform.position = new Vector3(-5f, 0.5f, 0f);
            rb.linearVelocity = new Vector3(12f * speed ,0f , UnityEngine.Random.Range(-1f,1f)* 12f * speed);
       }

       if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 currentVelocity = rb.linearVelocity;
            currentVelocity.z = -currentVelocity.z;
            rb.linearVelocity = currentVelocity;
        }

        if (collision.gameObject.CompareTag("Paddle"))
        {
            Vector3 currentVelocity = rb.linearVelocity;
            if (speed <= 1.02)
            {
                currentVelocity *= speed;
            }
            currentVelocity.x = -currentVelocity.x;
            rb.linearVelocity = currentVelocity;
        }
    }

    void SetCountText() 
    {
       LeftScore.text = LeftScoreCount.ToString();
       if (LeftScoreCount >= 10)
       {

       }
       RightScore.text = RightScoreCount.ToString();
       if (RightScoreCount >= 10)
       {

       }    
    }
}
