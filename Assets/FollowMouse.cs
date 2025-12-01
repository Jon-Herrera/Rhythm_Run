
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FollowMouse : MonoBehaviour
{
   private Camera mainCamera;
   [SerializeField]
   private float maxSpeed=10f;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        FollowMousePositiion();
    }
    private void FollowMousePositiion()
    {
        transform.position = GetWorldPositionFromMouse();
    }
    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
