using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class meatAudio : MonoBehaviour
{

    public AudioClip meatClip;
    public AudioSource meatSource;
    public float MaxVol = 1.0f;

    public float fadeInTime = 1.0f;
    public float fadeOutTime = 0.5f;

    private float volume = 0.0f;

    private bool isPlaying = false;

    void start()
    {
        meatSource.volume = 0.0f;
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
        meatSource.clip = meatClip;
        meatSource.loop = true;
        meatSource.Play();

        while (volume < MaxVol)
        {
            volume += Time.deltaTime / fadeInTime;
            meatSource.volume = volume;
            print(volume);
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

        while (volume > 0.0f)
        {
            volume -= Time.deltaTime / fadeOutTime;
            meatSource.volume = volume;
            yield return new WaitForSeconds(0);
        }

        meatSource.volume = 0.0f;
        meatSource.Stop();

    }

/*
    void PlayAudio()
        {
            audioSource.clip = audioClip;
            audioSource.Play();

        }

    void StopAudio()
        {
            audioSource.clip = audioClip;
            audioSource.Stop();
        }

*/

}