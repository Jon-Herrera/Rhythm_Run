using UnityEngine;


public class mo : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Animator animator;
    private Vector2 movement;
    // Update is called once per frame
    private float xPosLastFrame;
    void Update()
    {
        HandleMovement();
        FlipCharacterX();
    }

    private void FlipCharacterX()
    {
        float input = Input.GetAxis("Horizontal");
        if (input > 0 && transform.position.x > xPosLastFrame)
        {
            spriteRenderer.flipX = true;
        }
        else if (input < 0 && transform.position.x < xPosLastFrame)
        {
            spriteRenderer.flipX = false;
        }
        xPosLastFrame = transform.position.x;
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
}
