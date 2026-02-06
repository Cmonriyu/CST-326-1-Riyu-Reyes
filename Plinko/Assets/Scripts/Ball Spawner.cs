using UnityEngine;
using UnityEngine.InputSystem;
public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;

    void Start()
    {

    }

    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            Transform myTransform = GetComponent<Transform>();
            Instantiate(ballPrefab, new Vector3(UnityEngine.Random.Range(-1.45f,.65f),.8f,0f), Quaternion.identity);
        }
    }
}
