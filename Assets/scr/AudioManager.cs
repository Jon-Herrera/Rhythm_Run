using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip ---------")]
    public AudioClip background;
    public AudioClip powerUp;
    public AudioClip attack;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
     public void SetMusicPitch(float newPitch)
    {
        musicSource.pitch = newPitch;
    }
    public void PlayDeathDistort()
    {
        
        StartCoroutine(DeathDistort());
    }

    private IEnumerator DeathDistort()
    { 
        
        float originalPitch = musicSource.pitch;
        float originalVolume = musicSource.volume;
        musicSource.pitch = 2.0f;
        musicSource.volume = 1.0f;
        yield return new WaitForSeconds (0.2f);

        musicSource.pitch = 0.4f;
        musicSource.volume = 0.8f;
        yield return new WaitForSeconds (0.25f);

        musicSource.pitch = originalPitch;
        musicSource.volume = originalVolume;


    }
}
