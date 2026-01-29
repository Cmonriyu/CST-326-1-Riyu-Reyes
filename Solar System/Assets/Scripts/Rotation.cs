using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float yawDegreesPerSecond = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = GetComponent<Transform>();
        myTransform.Rotate(new Vector3(0, yawDegreesPerSecond, 0));
    }
}
