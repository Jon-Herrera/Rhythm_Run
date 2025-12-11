using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ManageScene : MonoBehaviour

{

 BackgroundAudio audioManager;
  [SerializeField]
  private string sceneToLoad;
    private void OnMouseDown()
    {
       Button btn = GetComponent<Button>();
    if (btn != null && !btn.interactable)
        return;  // Don’t load if locked

    SceneManager.LoadScene(sceneToLoad);
    audioManager.PlaySFX(audioManager.click);
    }
     public Button[] buttons;
    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false; 
        }
        for (int i = 0; i <unlockedLevel; i++)
        {
           buttons[i].interactable = true; 
        }
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<BackgroundAudio>();
    }
}
