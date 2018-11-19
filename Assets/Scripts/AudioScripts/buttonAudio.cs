using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class buttonAudio : MonoBehaviour
{

    public AudioClip audioClip;
    public AudioSource audioSource;

    private bool enter = true;

    void OnTriggerEnter(Collider other)
        {
            if (enter)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }

}