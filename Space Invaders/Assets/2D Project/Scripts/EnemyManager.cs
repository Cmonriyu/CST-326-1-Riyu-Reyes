using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    private bool right = true;
    private float movetime = 0f;
    public float moveint = 1f;
    public float movedist = .2f;
    public float Enemy4time = 0f;
    public float Enemy4int = 30f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadNewEnemies();
    }

    // Update is called once per frame
    void Update()

    {
        if (transform.childCount == 0)
        {
            LoadNewEnemies();
        }

        movetime += Time.deltaTime;

        if (movetime >= moveint)
        {
            MoveFormation();
            movetime = 0f;
        }

        Enemy4time += Time.deltaTime;

        if (Enemy4time >= Enemy4int)
        {
            Instantiate(Enemy4, new Vector3(-10f, 4.5f, 0f), Quaternion.identity);
            Enemy4time = 0f;
        }

    }


    void MoveFormation()
{   
    if (transform.position.x >= -2f || transform.position.x <= -8f)
        {
            right = !right;
            transform.position += Vector3.down * .1f;
        }
    if (right)
    {
        transform.position += Vector3.right * movedist;
    }
    else
    {
        transform.position += Vector3.left * movedist;
    }
}
    void LoadNewEnemies()
    {
        int rows = 5;
        int col = 11;
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < col; c++)
            {
                if (r == 0)
                {
                    Vector3 newPosition = new Vector3(c * 1f, r * -1f, 0);
                    GameObject Enemy2Instance = Instantiate(Enemy2, transform);
                    Enemy2Instance.transform.localPosition = newPosition;

                } else if (r == 1 || r == 2)
                {
                    Vector3 newPosition = new Vector3(c * 1f, r * -1f, 0);
                    GameObject Enemy1Instance = Instantiate(Enemy1, transform);
                    Enemy1Instance.transform.localPosition = newPosition;

                } else
                {
                    Vector3 newPosition = new Vector3(c * 1f, r * -1f, 0);
                    GameObject Enemy3Instance = Instantiate(Enemy3, transform);
                    Enemy3Instance.transform.localPosition = newPosition;

                }
            }
        }
    }
}
