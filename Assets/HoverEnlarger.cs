using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class HoverEnlarger : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public float sizeDifference = 1.05f;
    private Vector2 originalSize;
    private Transform getTransform;
    private void Awake()
    {
        getTransform = GetComponent<Transform>();
        originalSize=getTransform.localScale;
    }
   public void OnPointerEnter(PointerEventData eventData)
    {
        getTransform.localScale = originalSize * sizeDifference;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
         getTransform.localScale = originalSize;
    }
}
