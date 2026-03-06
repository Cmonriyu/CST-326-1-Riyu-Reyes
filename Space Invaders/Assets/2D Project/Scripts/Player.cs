using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    public Transform myTransform;
    public float guntime = 0f;
    public float gunint = .5f;

    void Start()
    {
        // todo - get and cache animator
    }
    
    void Update()
    {
        guntime += Time.deltaTime;
        if (guntime >= gunint)
        {
            if (transform.childCount == 1)
            {
                if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
                {
                    GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
                    Debug.Log("Bang!"); 
                    Destroy(shot,2f);
                    guntime = 0f;
                }
            }
        }
        

        

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            myTransform.position += Vector3.left * 4f * Time.deltaTime;
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            myTransform.position += Vector3.right * 4f * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject); 
            Destroy(gameObject);    
            Debug.Log("Player Dead Game Over");
        }
    }

}
