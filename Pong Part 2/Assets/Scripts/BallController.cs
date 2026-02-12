using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    // public Vector3 movement;
    public Transform myTransform;
    public float movementX;
    public float movementZ;
    public float speed = 1.000f;
    public TextMeshProUGUI LeftScore;
    public TextMeshProUGUI RightScore;
    public GameObject RedWin;
    public GameObject BlueWin;
    private int LeftScoreCount; 
    private int RightScoreCount;
    private bool startside;
    private bool powerupchoose;
    public int startangle;
    public float poweruptimer;
    public GameObject powerup;
    private float powerupspawner = 1f;
    private bool powerupactive = false;
    public GameObject LeftPaddle;
    public GameObject RightPaddle;
    public AudioClip Pong1;
    public AudioClip Pong2;
    public AudioClip Win;
    public AudioClip PowerUp;
    private bool PongSound;
    public AudioSource AudioSource;
    public Material FloorObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        BlueWin.SetActive(false);
        RedWin.SetActive(false);
        rb = GetComponent<Rigidbody>(); 
        LeftScoreCount = 0;
        RightScoreCount = 0;
        SetCountText();
        myTransform = GetComponent<Transform>();
        startside = UnityEngine.Random.value >= .5;
        if (startside == true)
        {
            movementX = -1f;
        } else
        {
            movementX = 1f;
        }
        movementZ = UnityEngine.Random.Range(-5f,5f);
        rb.linearVelocity = new Vector3(movementX * 9f * speed ,0f , movementZ * 7f * speed);
    }

    void Update()
    {
        
        if (powerupspawner > 0f)
        {
            Debug.Log(powerupspawner);
            powerupspawner -= Time.deltaTime;
        } else
        {   
            Debug.Log("PowerUp Spawned");
            Instantiate(powerup,new Vector3(UnityEngine.Random.Range(-3f,3f), 0.5f, UnityEngine.Random.Range(-3f,3f)), Quaternion.identity);
            powerupspawner = UnityEngine.Random.Range(10f,15f);
            
        }
        if (speed <= 2.5f)
        {
            speed += 0.01f * Time.deltaTime;
        }

        if (poweruptimer > 0f && powerupactive)
        {
            poweruptimer -= Time.deltaTime; 
        } else if (poweruptimer <= 0 && powerupactive)
        {
            powerupactive = false;
            ResetPowerups();
        }
    }

    void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.pitch = 1 * speed;
        if (collision.gameObject.CompareTag("LeftGoal"))
        {
            FloorObject.color =new Color(UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f));
            speed = 1.0f;
            RightScoreCount += 1;
            Debug.Log("Red Scores, Score is B:" + LeftScoreCount + " R:" + RightScoreCount);
            RightScore.color = new Color(UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f));

            SetCountText();
            myTransform.position = new Vector3(5f, 0.5f, 0f);
            rb.linearVelocity = new Vector3(-9f * speed ,0f , UnityEngine.Random.Range(-1f,1f)* 7f * speed);
            AudioSource.pitch = 1;
            AudioSource.PlayOneShot(Win);
        }
       if (collision.gameObject.CompareTag("RightGoal"))
        {
            FloorObject.color =new Color(UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f));
            Debug.Log("Blue Scores, Score is B:" + LeftScoreCount + " R:" + RightScoreCount);
            speed = 1.0f;
            LeftScoreCount += 1;
            LeftScore.color = new Color(UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f),UnityEngine.Random.Range(0f,1f));
            SetCountText();
            myTransform.position = new Vector3(-5f, 0.5f, 0f);
            rb.linearVelocity = new Vector3(9f * speed ,0f , UnityEngine.Random.Range(-1f,1f)* 7f * speed);
            AudioSource.pitch = 1;
            AudioSource.PlayOneShot(Win); 
       }

       if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 currentVelocity = rb.linearVelocity;
            currentVelocity.z = -currentVelocity.z;
            rb.linearVelocity = currentVelocity.normalized * 9f * speed ;
            PongSound = UnityEngine.Random.value >= .5;
            if (PongSound)
            {
                AudioSource.PlayOneShot(Pong1);
            } else
            {
                AudioSource.PlayOneShot(Pong2);
            }
        }

        if (collision.gameObject.CompareTag("Paddle"))
        {
            PongSound = UnityEngine.Random.value >= .5;
            if (PongSound)
            {
                AudioSource.PlayOneShot(Pong1);
            } else
            {
                AudioSource.PlayOneShot(Pong2);
            }
            ContactPoint point = collision.contacts[0];
            Transform paddleTransform = collision.transform;
            float paddleHeight = paddleTransform.localScale.z;
            float factor = (point.point.z - paddleTransform.position.z) / (paddleHeight / 2);
            Vector3 currentVelocity = rb.linearVelocity;
            currentVelocity.x = -currentVelocity.x;
            currentVelocity.z = factor * 3f;
            rb.linearVelocity = currentVelocity.normalized * 9f * speed;

        }
    }

    void OnTriggerEnter(Collider collision)
    {
        AudioSource.pitch = 1;
        AudioSource.PlayOneShot(PowerUp);
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            Debug.Log("PowerUp hit");
            Destroy(collision.gameObject);
            powerupchoose = UnityEngine.Random.value >= .5;
            poweruptimer = 5f;
            if (powerupchoose == true)
            {
                Debug.Log("Ball Speed Up");
                powerupactive = true;
                speed = 2f;
                Vector3 currentVelocity = rb.linearVelocity;
                rb.linearVelocity = currentVelocity.normalized * 9f * speed ;
            } else
            {
                Debug.Log("Paddle Size Down");
                powerupactive = true;
                LeftPaddle.transform.localScale = new Vector3(.4f,1f,UnityEngine.Random.Range(.3f,1.6f));
                RightPaddle.transform.localScale = new Vector3(.4f,1f,UnityEngine.Random.Range(.3f,1.6f));
            }
            
        }
    }

    void ResetPowerups()
    {
        Debug.Log("PowerUp Reset");
        speed = 1f;
        LeftPaddle.transform.localScale = new Vector3(.4f,1f,2.5f);
        RightPaddle.transform.localScale = new Vector3(.4f,1f,2.5f);
    }

    void SetCountText() 
    {       
       LeftScore.fontSize = 100 + 10 * LeftScoreCount;
       LeftScore.text = LeftScoreCount.ToString();
       if (LeftScoreCount > 10)
       {
            Destroy(gameObject);
            BlueWin.SetActive(true);
            Debug.Log("Game Over, Blue Wins, Score is B:" + LeftScoreCount + " R:" + RightScoreCount);
            LeftScoreCount = 0;
            RightScoreCount = 0;
            SetCountText();
       }
        RightScore.fontSize = 100 + 10 * RightScoreCount;
        RightScore.text = RightScoreCount.ToString();
       if (RightScoreCount > 10)
       {    
            Destroy(gameObject);
            RedWin.SetActive(true);
            Debug.Log("Game Over, Red Wins, Score is B:" + LeftScoreCount + " R:" + RightScoreCount);
            LeftScoreCount = 0;
            RightScoreCount = 0;
            SetCountText();
       }    
    }
}
