
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftMove : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody rb;
    public Vector3 movement;
    public Transform myTransform;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myTransform = GetComponent<Transform>();
    }

    void Update()
    {
    //    if (myTransform.position.z < -3.25f)
    //     {   
    //         movement = new Vector3(-8f,.5f,-3.25f);
    //         rb.MovePosition(movement);
    //     }
    //     if (myTransform.position.z > 3.25f)
    //     {
    //         movement =  new Vector3(-8f,.5f,3.25f);
    //         rb.MovePosition( movement);
    //     }
    }

    void FixedUpdate()
    {
        
        if (Keyboard.current.sKey.isPressed)
        {
            rb.MovePosition(rb.position - Vector3.forward * 5f * Time.deltaTime);
        }

        if (Keyboard.current.wKey.isPressed)
        {
            rb.MovePosition(rb.position + Vector3.forward * 5f * Time.deltaTime);
        }


    }

}
