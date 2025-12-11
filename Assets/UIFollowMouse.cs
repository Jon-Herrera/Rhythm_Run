using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIFollowMouse : MonoBehaviour, IPointerClickHandler
{

    public string sceneName;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(sceneName);
    }
  /* private RectTransform rect;
   [SerializeField]
   private float maxSpeed = 10f;
    // this is used for all 6 game level scenens since I want the mouse to be able to interact with the 
    // return icon on the top level as its static
    void Awake()
    {
        rect = GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update()
    {
       FollowMousePosition();
    }

    private void FollowMousePosition()
    {
        Vector3 targetPos = Input.mousePosition;
        rect.position = Vector3.MoveTowards(
            rect.position, targetPos,maxSpeed * Time.deltaTime
        );
   
    }
    */
}
