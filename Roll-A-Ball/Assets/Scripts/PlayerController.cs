using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; 
    private int count;
    public GameObject winTextObject;
    private float movementX;
    private float movementY;
    public float speed = 0; 
    public TextMeshProUGUI countText;

    void Start() {
        count = 0;
        rb = GetComponent <Rigidbody>(); 
        SetCountText();
        winTextObject.SetActive(false);
    }
    private void FixedUpdate() {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        if (this.transform.position.y < -10)
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }
   }
    
    void OnTriggerEnter(Collider other){ 
        if (other.gameObject.CompareTag("PickUp")) {
            
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }
    void OnMove (InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }
    void SetCountText() 
    {
       countText.text =  "Count: " + count.ToString();
       if (count >= 17)
       {
           winTextObject.SetActive(true);
           Destroy(GameObject.FindGameObjectWithTag("Enemy"));

       }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
        Destroy(gameObject);     
        winTextObject.gameObject.SetActive(true);
        winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!" + '\n' + "Restarting...";
       }
    }
}
