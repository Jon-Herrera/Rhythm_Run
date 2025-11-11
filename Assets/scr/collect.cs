using UnityEngine;

public class collect : MonoBehaviour
{
    private Object thisObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisObject = GetComponent<Object>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            Destroy(gameObject);
        }
    }
}
