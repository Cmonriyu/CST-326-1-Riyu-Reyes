using TMPro;
using UnityEngine.InputSystem;
using UnityEngine;

public class CharacterDriver : MonoBehaviour
{
    public float walkspeed = 5f;
    public float runspeed = 10f;
    public float groundAcceleration = 15f;
    public float apexHeight = 4.5f;
    public float apexTime = 0.5f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI creditText;
    public TextMeshProUGUI youWinText;
    private int scorecount = 0;
    private int creditcount = 0;

    public AudioClip blockbreak;
    public AudioClip questionbreak;
    public AudioSource audioSource;
    public GameObject coinBlockPrefab;
    Vector2 _velocity;
    CharacterController _controller;
    Quaternion facingRight;
    Quaternion facingLeft;
    void Start()
    {

        facingRight = Quaternion.identity;
        facingLeft = Quaternion.Euler(0f,180f,0f);
        _controller = GetComponent<CharacterController>();
        youWinText.gameObject.SetActive(false);


    }

    void Update()
    {
        if (transform.position.y <= -1)
        {           
            _controller.enabled = false;     
            transform.position = new Vector3(11f, 2.73f, 0f); 
            _velocity = new Vector2(0f,0f);             
            _controller.enabled = true; 
            
        }
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
            if(Keyboard.current.dKey.isPressed) direction = 1f;
            else if(Keyboard.current.aKey.isPressed) direction = -1f;
            else direction = 0f;

            if (direction != 0f)
                transform.rotation = (direction > 0f) ? facingRight : facingLeft;

            _velocity.x += direction * groundAcceleration * 0.5f * Time.deltaTime;
            _velocity.x = Mathf.Clamp(_velocity.x, -walkspeed, walkspeed);
            }   
        
            float gravity = 2f * apexHeight / (apexTime * apexTime);
            _velocity.y -= gravity * gravityModifier * Time.deltaTime; 
            float deltaX = _velocity.x * Time.deltaTime;
            float deltaY = _velocity.y * Time.deltaTime;
            Vector3 deltaPosition = new (deltaX,deltaY,0f);
            CollisionFlags collisions = _controller.Move(deltaPosition);
            if ((collisions & CollisionFlags.CollidedAbove) != 0)
        {
            _velocity.y = -1f;
            RaycastHit hitAbove;
            Vector3 origin = _controller.transform.position + new Vector3(0f, _controller.height / 2f, 0f);
            float distance = 4f;

            if (Physics.Raycast(origin, Vector3.up, out hitAbove, distance))
            {
                if (hitAbove.collider.CompareTag("Question"))
                {
                    Vector3 spawnPosition = hitAbove.transform.position + new Vector3(0f, 1f, 0f);
                    Destroy(hitAbove.collider.gameObject, 0f);
                    Instantiate(coinBlockPrefab, spawnPosition, Quaternion.identity);
                    audioSource.PlayOneShot(questionbreak, 0.1f);
                    scorecount += 100;
                    scoreText.text = $"MARIO\n{scorecount:000000}";
                }
                else if (hitAbove.collider.CompareTag("Brick"))
                {
                    Destroy(hitAbove.collider.gameObject, 0f);
                    audioSource.PlayOneShot(blockbreak, 0.1f);
                    scorecount += 100;
                    scoreText.text = $"MARIO\n{scorecount:000000}";
                }
            }
        }
        if ((collisions & CollisionFlags.CollidedAbove) != 0)
            _velocity.x = 0f;
        // Debug.Log($"GroundedL: {_controller.isGrounded}");
        
        
    }
    private void OnTriggerEnter(Collider hit){
        if (hit.GetComponent<Collider>().CompareTag("Coin"))
        {
            Destroy(hit.GetComponent<Collider>().gameObject, 0f);
            audioSource.PlayOneShot(questionbreak,.1f);
            creditcount += 1;
            creditText.text = $"\nx{creditcount:00}";
            

        } else if (hit.GetComponent<Collider>().CompareTag("Enemy")){
            _controller.enabled = false;
            transform.position = new Vector3(11f,2.73f,0f);
            Debug.Log("Entered enemy trigger!");
            _velocity.x = 0f;
            _velocity.y = 0f;
            _controller.enabled = true;
            _velocity.y = -1f;
        
        } else if (hit.GetComponent<Collider>().CompareTag("Goal")){
            youWinText.gameObject.SetActive(true);
            _controller.enabled = false;
        }
    }

}
