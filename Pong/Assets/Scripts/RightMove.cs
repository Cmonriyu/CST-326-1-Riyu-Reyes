
using UnityEngine;
using UnityEngine.InputSystem;

public class RightMove : MonoBehaviour
{
    public float speed = 10f;
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
        // if (myTransform.position.z < -3.25f)
        // {   
        //     movement = new Vector3(-8f,.5f,-3.25f);
        //     rb.MovePosition(movement);
        // }
        // if (myTransform.position.z > 3.25f)
        // {
        //     movement = new Vector3(-8f,.5f,3.25f);
        //     rb.MovePosition( movement);
        // }
        
    }

    void FixedUpdate()
    {
        if (Keyboard.current.lKey.isPressed)
        {
            rb.MovePosition(rb.position - Vector3.forward * 5f * Time.deltaTime );
        }

        if (Keyboard.current.pKey.isPressed)
        {
            rb.MovePosition(rb.position + Vector3.forward * 5f * Time.deltaTime );
        }


    }

}
