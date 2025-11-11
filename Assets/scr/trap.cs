using System;
using UnityEngine;

public class trap : MonoBehaviour
{
    public float bounceForce = 10f;
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerBounce(collision.gameObject);
        }
    }
    
    private void HandlePlayerBounce(GameObject player)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        if (rb)
        {
            //reset player velocity
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

            //apply bounce force
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
