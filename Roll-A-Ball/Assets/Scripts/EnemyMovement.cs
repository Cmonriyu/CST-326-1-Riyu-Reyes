using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;
    private NavMeshAgent navMeshAgent;
    private float time = 300;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
       {    
           navMeshAgent.SetDestination(player.position);
           
       } else
       {
            time--;
           if (time <= 0)
            {
                SceneManager.LoadScene( SceneManager.GetActiveScene().name );
            }
       }
    
    }
}
