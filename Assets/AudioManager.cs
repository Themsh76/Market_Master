using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------- Audio Clip ----------")]
    public AudioClip background1; //Die Namen für Sound kann man noch anpassen
    public AudioClip background2;
    public AudioClip Sound1;
    public AudioClip Sound2;
    public AudioClip Sound3;
   
    private void Start()
    {
        musicSource.clip = background1;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);

    }

}
