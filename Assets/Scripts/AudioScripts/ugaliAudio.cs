using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ugaliAudio : MonoBehaviour
{

    public AudioClip ugaliClip;
    public float MaxVol = 1.0f;

    public float fadeInTime = 1.0f;
    public float fadeOutTime = 0.5f;

    private AudioSource audioSource;

    private float volume = 0.0f;

    private bool isPlaying = false;

    void start()
    {
        audioSource.volume = 0.0f;
    }

    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Stove" && isPlaying == false)
            {
                StopCoroutine(fadeOut());
                StartCoroutine(fadeIn());
            }

        }

    IEnumerator fadeIn()
    {
        isPlaying = true;

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = ugaliClip;
        audioSource.loop = true;
        audioSource.Play();

        while (volume < MaxVol)
        {
            volume += Time.deltaTime / fadeInTime;
            audioSource.volume = volume;
            yield return new WaitForSeconds(0);
        }
    }

    void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Stove" && isPlaying == true)
            {
                StartCoroutine(fadeOut());
            }
        }

    IEnumerator fadeOut()
    {
        isPlaying = false;

        audioSource = gameObject.GetComponent<AudioSource>();

        while (volume > 0.0f)
        {
            volume -= Time.deltaTime / fadeOutTime;
            audioSource.volume = volume;
            yield return new WaitForSeconds(0);
        }

        audioSource.volume = 0.0f;
        audioSource.Stop();

    }

}