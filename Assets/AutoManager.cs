using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;




public class Automanager : MonoBehaviour
{
    [Header("----------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------- Audio Clip ----------")]
    public AudioClip background1; // Die Namen für Sound können angepasst werden
    public AudioClip background2;
    public AudioClip Sound1;
    public AudioClip Sound2;
    public AudioClip Sound3;

    private string previousScene; // Um die vorherige Szene zu verfolgen

    public static Automanager instance;

 

    private void Start()
    {
        // Startbildschirm erkennen und Hintergrundmusik entsprechend abspielen
        if (SceneManager.GetActiveScene().name == "StartScreen")
        {
            musicSource.clip = background1;
            PlayBackgroundMusic();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;

        // Wenn die aktuelle Szene nicht der Startbildschirm ist, setze die Hintergrundmusik entsprechend
        if (sceneName != "StartScreen")
        {
            if (previousScene == "StartScreen" || previousScene == null)
            {
                musicSource.clip = background2;
                PlayBackgroundMusic();
            }
        }
        else // Wenn die aktuelle Szene der Startbildschirm ist, spiele Hintergrundmusik 1 ab
        {
            musicSource.clip = background1;
            PlayBackgroundMusic();
        }

        previousScene = sceneName; // Aktualisieren der vorherigen Szene
    }

    private void PlayBackgroundMusic()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    private void StopBackgroundMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }


    public void PlaySFX(AudioClip clip)
    {
        // Check if the SFXSource game object is active before playing the sound
        if (!SFXSource.gameObject.activeInHierarchy)
        {
            UnityEngine.Debug.LogWarning("SFXSource game object is inactive. Cannot play sound effect.");
            return;
        }

        SFXSource.PlayOneShot(clip);
    }


}