using UnityEngine;

public class Skit : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
    }
}
