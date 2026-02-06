
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftMove : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody rb;
    public Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
       
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
