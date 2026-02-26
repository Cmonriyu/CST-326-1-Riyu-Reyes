using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    public Camera MCamera;
    private Transform myTransform;
    public TextMeshProUGUI score;
    private int scorecount = 0;
    public AudioClip blockbreak;
    public AudioClip questionbreak;
    public AudioSource audioSource;
    public TextMeshProUGUI player2;
    public TextMeshProUGUI player1;
    public TextMeshProUGUI top;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myTransform = transform;
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            Debug.Log("camleft");
            myTransform.position += Vector3.left * 15f * Time.deltaTime;
            player2.gameObject.SetActive(false);
            player1.gameObject.SetActive(false);
            top.gameObject.SetActive(false);
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            Debug.Log("camright");
            myTransform.position += Vector3.right * 15f * Time.deltaTime;
            player2.gameObject.SetActive(false);
            player1.gameObject.SetActive(false);
            top.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            RaycastHit whathit = new RaycastHit ();
            if (Physics.Raycast (MCamera.ScreenPointToRay (Input.mousePosition), out whathit))
            {
                Debug.Log("raycasted");
            }

            if (whathit.collider.gameObject.CompareTag ("Brick")) {
                Debug.Log ("brick");
                audioSource.PlayOneShot(blockbreak);
                Destroy(whathit.collider.gameObject);
            }

            if (whathit.collider.gameObject.CompareTag ("Dirt")) {
                Debug.Log ("dirt");
                audioSource.PlayOneShot(blockbreak);
                Destroy(whathit.collider.gameObject);
            }

            if (whathit.collider.gameObject.CompareTag ("Stone")) {
                Debug.Log ("stone");
                audioSource.PlayOneShot(blockbreak);
                Destroy(whathit.collider.gameObject);
            }

            if (whathit.collider.gameObject.CompareTag ("Question")) {
                Debug.Log ("question");
                audioSource.PlayOneShot(questionbreak);
                Destroy(whathit.collider.gameObject);
                scorecount += 1;
                score.text = $"MARIO\n{scorecount:000000}";
                
                
            }

        }
    
    }
}
