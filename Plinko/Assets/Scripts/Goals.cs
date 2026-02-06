using UnityEngine;

public class Goals : MonoBehaviour
{
    public GameObject Goal;
    public int count = 0;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
        {
            count++;
            Debug.Log(gameObject.name + ": " + count);
            Destroy(collision.gameObject);
        }
}
