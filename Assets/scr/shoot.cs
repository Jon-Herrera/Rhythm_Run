using System.Collections;

using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 5.0f;
    private int direction = 1;

    public void SetDirection(bool isForward)
    {
        direction = isForward ? 1 : -1;
    }

    void Update()
    {
        transform.position += transform.right * direction * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}