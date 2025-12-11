using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour

{

    BackgroundAudio audioManager;
  [SerializeField]
  private string sceneToLoad;
    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneToLoad);
        audioManager.PlaySFX(audioManager.click);
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<BackgroundAudio>();
    }
}
