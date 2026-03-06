using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadNewEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadNewEnemies()
    {
        int rows = 4;
        int col = 10;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < col; c++)
            {
                if (r == 0)
                {
                     
                }
            }
        }
    }
}
