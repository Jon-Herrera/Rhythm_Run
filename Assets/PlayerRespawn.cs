using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerRespawn : MonoBehaviour
{
    private Vector3 startPosition;
    private Rigidbody2D rb;

    private void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Respawn()
    {
        transform.position = startPosition;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}