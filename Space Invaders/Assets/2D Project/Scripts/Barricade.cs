using UnityEngine;

public class Barricade : MonoBehaviour
{
        private int Health = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet") ||
            collision.gameObject.layer == LayerMask.NameToLayer("EnemyBullet"))
        {
            Debug.Log("Barricade hit");
            Destroy(collision.gameObject);
            Health -= 1;
            if (Health == 0)
            {
                Destroy(gameObject);

            }
        }
    }
}
