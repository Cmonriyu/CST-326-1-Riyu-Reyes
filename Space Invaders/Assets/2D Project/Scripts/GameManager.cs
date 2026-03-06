using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float scorecount = 0f;

  
    void Start()
    {
       Enemy1.OnEnemyDied += OnEnemyDied;
       Enemy2.OnEnemyDied += OnEnemyDied;
       Enemy3.OnEnemyDied += OnEnemyDied;
       Enemy4.OnEnemyDied += OnEnemyDied;
    }

    void OnDestroy()
    {
        Enemy1.OnEnemyDied -= OnEnemyDied;
        Enemy2.OnEnemyDied -= OnEnemyDied;
        Enemy3.OnEnemyDied -= OnEnemyDied;
        Enemy4.OnEnemyDied -= OnEnemyDied;
    }

    void OnEnemyDied(float score)
    {
        Debug.Log($"Killed enemy worth {score}");
        scorecount += score;
        scoreText.text = $"Credit\n{scorecount:000000}";

    }
}
