using UnityEngine;
using UnityEngine.SceneManagement;

public class mo : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioManager audioManager;
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

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float health=0.5f;
    [SerializeField] private float EnemyDamgeAmount=0.2f;

    [SerializeField] private Transform respawnPoint;

    
    void Start()
    {
        count = 0;
        SetCountText();
        // if(healthBar != null)
        // {
        //     healthBar.SetHealth(health);
        // }
        // else
        // {
        //     Debug.LogWarning("HealthBar not assigned!");
        // }
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
            audioPlayer.pitch = UnityEngine.Random.Range(1f, 1.5f);
            audioPlayer.Play();
            //increase bg music volume/ speed
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Level 3-Venice");
        }
        if (other.gameObject.CompareTag("finish2"))
        {
            SceneManager.LoadScene("Level 3-00s");
        }
        if (other.gameObject.CompareTag("Portal"))
        {
            PlayerPrefs.SetInt("CointCount", count);
            PlayerPrefs.Save();
            SceneManager.LoadScene("CongratsScene");
        }
        

        if(other.gameObject.CompareTag("Enemy"))
        {
            health-=EnemyDamgeAmount;
            healthBar.SetHealth(health);

            if(health <= 0f)
            {
              SceneManager.LoadScene("GameOver");
            }
                

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 knockbackDir = new Vector2(transform.position.x - other.transform.position.x, 0).normalized;
            float knockbackForce = 5;
            rb.AddForce(-knockbackDir * knockbackForce, ForceMode2D.Impulse);
        }

        
}

   
    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1; 
        transform.localScale = currentScale;
    }

   
}
