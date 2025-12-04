using UnityEngine;
using UnityEngine.SceneManagement;

public class mo : MonoBehaviour
{
    public AudioSource audioPlayer;
    [SerializeField] private float speed = 5f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Animator animator;
    private Vector2 movement;
    // Update is called once per frame
    private float xPosLastFrame;
    private int count;
    //public TextMeshProUGUI countText;
    public GameObject projectilePrefab;
    public Transform launchOffset;
    public bool forward = true;
    void Start()
    {
        count = 0;
        SetCountText();
    }
    void Update()
    {
        HandleMovement();
        FlipCharacterX();
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject proj = Instantiate(projectilePrefab, launchOffset.position, transform.rotation);
            Shoot bullet = proj.GetComponent<Shoot>();
            bullet.SetDirection(forward);
        }
    }
    private void FlipCharacterX()
    {
        float input = Input.GetAxis("Horizontal");
        if (input > 0 && !forward)
        {
            Flip();
            forward = true;
        }
        else if (input < 0 && forward)
        {
            Flip();
            forward = false;
        }
    }
    private void HandleMovement()
    {
        float input = Input.GetAxis("Horizontal");
        movement.x = input * speed * Time.deltaTime;
        transform.Translate(movement);
        if (input != 0)
        {
            animator.SetBool("New Bool", true);
        }
        else
        {
            animator.SetBool("New Bool", false);
        }
    }
    void SetCountText()
    {
        //countText.text =  "Count: " + count.ToString();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("Pickup"))
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            audioPlayer.Play();
            //increase bg music volume/ speed
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Level 2-80s");
        }
        if (other.gameObject.CompareTag("finish2"))
        {
            SceneManager.LoadScene("Level 3-00s");
        }
    }
    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1; 
        transform.localScale = currentScale;
    }

   
}
