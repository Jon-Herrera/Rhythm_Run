
using UnityEngine;

public class jump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private float jumpF = 6f;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && GetGrounded())
        {
            Jump();
        }
    }
    private bool GetGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 3f, LayerMask.GetMask("Ground"));
    }
    private void Jump()
    {
        rigid.AddForce(Vector2.up * jumpF, ForceMode2D.Impulse);
    }
}
