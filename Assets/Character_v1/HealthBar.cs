using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector2 offset = new Vector2(0, 0);
    [SerializeField] private GameObject fill;


    private float initialScaleX;

    void Start()
    {
        initialScaleX = fill.transform.localScale.x;
        offset=gameObject.transform.position-target.position;
        SetHealth(1.0f);
    }

    void LateUpdate()
    {
        // Follow the character
        transform.position = target.position + (Vector3)offset;
    }

    public void SetHealth(float normalized)
    {
        normalized = Mathf.Clamp01(normalized);

        Vector3 s = fill.transform.localScale;
        s.x = initialScaleX * normalized;
        fill.transform.localScale = s;
    }
}
