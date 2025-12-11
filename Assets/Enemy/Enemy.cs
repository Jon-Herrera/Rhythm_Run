using UnityEngine;

public class Enemy : MonoBehaviour

{
    [Header("Patrol Settings")]
    [SerializeField] private float speed = 2f;           // movement speed
    [SerializeField] private float patrolDistance = 3f;  // how far from start it moves (one side)

    private bool movingRight = true;
    private float leftLimit;
    private float rightLimit;

    private void Start()
    {
        // Use starting position as center of patrol
        float startX = transform.position.x;
        leftLimit = startX - patrolDistance;
        rightLimit = startX + patrolDistance;
    }

    private void Update()
    {
        // 1. Move left/right
        float direction = movingRight ? 1f : -1f;
        transform.position += new Vector3(direction * speed * Time.deltaTime, 0f, 0f);

        // 2. If we reach a limit, flip direction
        if (movingRight && transform.position.x >= rightLimit)
        {
            movingRight = false;
            Flip();
        }
        else if (!movingRight && transform.position.x <= leftLimit)
        {
            movingRight = true;
            Flip();
        }
    }

    private void Flip()
    {
        // Flip only on X so sprite faces the right way
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }

}