using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public delegate void EnemyDiedFunc(float points);
    public static event EnemyDiedFunc OnEnemyDied;
    public GameObject enemyBulletPrefab;


    void Update()
    {
       if (Random.Range(0f,10000f) < 1f)
        {
            GameObject EnemyShot = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
            Destroy(EnemyShot,2f);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Enemy2 hit");
            
            if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);


                OnEnemyDied?.Invoke(30);
            }
        }
    }
}
