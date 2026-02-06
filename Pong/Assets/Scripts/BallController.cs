
using System.Collections.Generic;
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
    public GameObject RedWin;
    public GameObject BlueWin;
    public int LeftScoreCount;
    public int RightScoreCount;
    public bool startside;
    public int startangle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        BlueWin.SetActive(false);
        RedWin.SetActive(false);
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
        movementZ = UnityEngine.Random.Range(-5f,5f);
        rb.linearVelocity = new Vector3(movementX * 9f * speed ,0f , movementZ * 7f * speed);
    }

    
    void FixedUpdate()
    {
        if (speed <= 2.5f)
        {
            speed += .0005f;
        }
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
            rb.linearVelocity = new Vector3(-9f * speed ,0f , UnityEngine.Random.Range(-1f,1f)* 7f * speed);
        }
       if (collision.gameObject.CompareTag("RightGoal"))
        {
            Debug.Log("Right Hit");
            speed = 1.0f;
            LeftScoreCount += 1;
            SetCountText();
            myTransform.position = new Vector3(-5f, 0.5f, 0f);
            rb.linearVelocity = new Vector3(9f * speed ,0f , UnityEngine.Random.Range(-1f,1f)* 7f * speed);
            
       }

       if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 currentVelocity = rb.linearVelocity;
            currentVelocity.z = -currentVelocity.z;
            rb.linearVelocity = currentVelocity.normalized * 9f * speed ;
        }

        if (collision.gameObject.CompareTag("Paddle"))
        {
            ContactPoint point = collision.contacts[0];
            Transform paddleTransform = collision.transform;
            float paddleHeight = paddleTransform.localScale.z;
            float factor = (point.point.z - paddleTransform.position.z) / (paddleHeight / 2);
            Vector3 currentVelocity = rb.linearVelocity;
            currentVelocity.x = -currentVelocity.x;
            currentVelocity.z = factor * 3f;
            rb.linearVelocity = currentVelocity.normalized * 9f * speed;
        }
    }

    // void OnTriggerEnter(Collider collision)
    // {
    //     if (collision.gameObject.CompareTag("Paddle"))
    //     {
    //         Vector3 currentVelocity = rb.linearVelocity;
    //         currentVelocity.x = -currentVelocity.x;
    //         rb.linearVelocity = currentVelocity.normalized * 9f * speed;
    //     }
    // }



    void SetCountText() 
    {
       LeftScore.text = LeftScoreCount.ToString();
       if (LeftScoreCount >= 9)
       {
            Destroy(gameObject);
            BlueWin.SetActive(true);
       }
       RightScore.text = RightScoreCount.ToString();
       if (RightScoreCount >= 9)
       {    
            Destroy(gameObject);
            RedWin.SetActive(true);
       }    
    }
}
