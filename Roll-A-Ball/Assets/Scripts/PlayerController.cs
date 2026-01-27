using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; 
    private float movementX;
    private float movementY;
    public float speed = 0; 
    public TextMeshProUGUI countText;

    void Start() {
        rb = GetComponent <Rigidbody>(); 
        SetCountText();

    }
    private void FixedUpdate() {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

    }
    
    void OnTriggerEnter(Collider other){ 
        if (other.gameObject.CompareTag("PickUp")) {
            SetCountText();
            other.gameObject.SetActive(false);
        }
    }
    void OnMove (InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

    void SetCountText() {
       countText.text =  "Count: " + count.ToString();
    }

}
