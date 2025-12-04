using UnityEngine;
using UnityEngine.Rendering;

public class SimpleMovement : MonoBehaviour
{
    public float speed = 5f;
    public float offset=0f;
    public float amplitude = 15f;
    private float baseZ;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseZ = transform.localEulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = baseZ + Mathf.Sin(Time.time * speed + offset) * amplitude;

        Vector3 swing = transform.localEulerAngles;
        swing.z = angle;
        transform.localEulerAngles = swing;
    }
}
