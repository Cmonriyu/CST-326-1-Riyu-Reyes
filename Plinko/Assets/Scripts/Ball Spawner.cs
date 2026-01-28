using UnityEngine;
using UnityEngine.InputSystem;
public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;

    void Start()
    {
    
        Instantiate(ballPrefab);

    }

    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            Transform myTransform = GetComponent<Transform>();
            Instantiate(ballPrefab, myTransform.position, Quaternion.identity);
        }
    }
}
