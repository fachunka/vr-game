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
                float pitch = 1.0f + Random.Range(-0.05f, 0.05f);
                audioSource.clip = audioClip;
                audioSource.pitch = pitch;
                audioSource.Play();
            }
        }

}