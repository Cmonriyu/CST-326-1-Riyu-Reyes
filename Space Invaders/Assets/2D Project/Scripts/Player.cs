using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootOffsetTransform;
    public Transform myTransform;

    void Start()
    {
        // todo - get and cache animator
    }
    
    void Update()
    {
        if (transform.childCount > 1)
        {
            if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
                Debug.Log("Bang!");
                Destroy(shot,3f);
            }
        }

        

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            myTransform.position += Vector3.left * 3f * Time.deltaTime;
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            myTransform.position += Vector3.right * 3f * Time.deltaTime;
        }
    }
}
