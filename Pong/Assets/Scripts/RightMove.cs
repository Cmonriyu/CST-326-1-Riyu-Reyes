using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightMove : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    public Vector3 movement;
    public float forceStrength = 10f;
    public float paddleSpeed  = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        
    }

    void FixedUpdate()
    {
        if (Keyboard.current.lKey.isPressed)
        {
            rb.MovePosition(rb.position - Vector3.forward * 5f * Time.deltaTime );
        }

        if (Keyboard.current.oKey.isPressed)
        {
            rb.MovePosition(rb.position + Vector3.forward * 5f * Time.deltaTime );
        }


    }

}
