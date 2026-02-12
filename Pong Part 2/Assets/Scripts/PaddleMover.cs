
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftMove : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody lrb;
    public Rigidbody rrb;
    public Vector3 movement;
    public Transform myTransform;
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        if (Keyboard.current.sKey.isPressed)
        {
            lrb.MovePosition(lrb.position - Vector3.forward * 5f * Time.deltaTime);
        }

        if (Keyboard.current.wKey.isPressed)
        {
            lrb.MovePosition(lrb.position + Vector3.forward * 5f * Time.deltaTime);
        }
    
        if (Keyboard.current.lKey.isPressed)
        {
            rrb.MovePosition(rrb.position - Vector3.forward * 5f * Time.deltaTime );
        }

        if (Keyboard.current.pKey.isPressed)
        {
            rrb.MovePosition(rrb.position + Vector3.forward * 5f * Time.deltaTime );
        }
    }
}
