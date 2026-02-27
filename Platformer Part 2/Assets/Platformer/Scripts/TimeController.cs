using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI gameOverText;
    public GameObject player;

    float timeLeft = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = $"TIME\n {((int)timeLeft).ToString("#")}";
        if (timeLeft <= 0)
        {
            Debug.Log("Game Over");
            gameOverText.gameObject.SetActive(true);
            Destroy(player);
        }

    }
}
