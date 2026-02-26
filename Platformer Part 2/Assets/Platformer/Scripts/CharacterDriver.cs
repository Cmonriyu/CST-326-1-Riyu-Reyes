using UnityEngine.InputSystem;
using UnityEngine;

public class CharacterDriver : MonoBehaviour
{
    public float walkspeed = 5f;
    public float runspeed = 10f;
    public float groundAcceleration = 15f;
    public float apexHeight = 4.5f;
    public float apexTime = 0.5f;
    Vector2 _velocity;
    CharacterController _controller;
    Quaternion facingRight;
    Quaternion facingLeft;
    void Start()
    {

        facingRight = Quaternion.identity;
        facingLeft = Quaternion.Euler(0f,180f,0f);
        _controller = GetComponent<CharacterController>();


    }

    void Update()
    {

        float direction = 0f;
        if(Keyboard.current.dKey.isPressed) direction += 1f;
        if(Keyboard.current.aKey.isPressed) direction -= 1f;
        bool jumpPressedThisFrame = Keyboard.current.spaceKey.wasPressedThisFrame;
        bool jumpHeld = Keyboard.current.spaceKey.isPressed;

        float gravityModifier = 1f;

        if (_controller.isGrounded)
        {
            if (direction != 0f){
                if (Mathf.Sign(direction) != Mathf.Sign(_velocity.x))
                    _velocity.x = 0f;

                _velocity.x += direction * groundAcceleration * Time.deltaTime;
                _velocity.x = Mathf.Clamp(_velocity.x, -walkspeed, walkspeed);
                transform.rotation = (direction > 0f) ? facingRight : facingLeft;
                
            } 
            else
            {
                _velocity.x = Mathf.MoveTowards(_velocity.x, 0f, groundAcceleration * Time.deltaTime);
            }

            if(jumpPressedThisFrame) 
                _velocity.y = 1.4f * apexHeight / apexTime;

        }
        else
        {
            if (!jumpHeld)
            {
                gravityModifier =  2f;
            }    
        }   
        
        float gravity = 2f * apexHeight / (apexTime * apexTime);
        _velocity.y -= gravity * gravityModifier * Time.deltaTime; 

        float deltaX = _velocity.x * Time.deltaTime;
        float deltaY = _velocity.y * Time.deltaTime;

        Vector3 deltaPosition = new (deltaX,deltaY,0f);
        CollisionFlags collisions = _controller.Move(deltaPosition);
        if ((collisions & CollisionFlags.CollidedAbove) != 0)
            _velocity.y = -1f;

        if ((collisions & CollisionFlags.CollidedAbove) != 0)
            _velocity.x = -1f;

        _controller.Move(deltaPosition);

        // Debug.Log($"GroundedL: {_controller.isGrounded}");
        
        
    }
}
