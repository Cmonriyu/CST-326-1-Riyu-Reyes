using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    public delegate void EnemyDiedFunc(float points);
    public static event EnemyDiedFunc OnEnemyDied;
    public Transform myTransform;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy4 hit");
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);


            OnEnemyDied?.Invoke(1000);
        }
    }

    void Update()
    {
        myTransform.position += Vector3.right * 3f * Time.deltaTime;
    }
    
}
