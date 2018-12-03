using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ugaliAudio : MonoBehaviour
{

    public AudioClip ugaliClip;
    public AudioSource ugaliSource;
    public float MaxVol = 1.0f;

    public float fadeInTime = 1.0f;
    public float fadeOutTime = 0.5f;

    private float volume = 0.0f;

    private bool isPlaying = false;

    void start()
    {
        ugaliSource.volume = 0.0f;
    }

    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Stove" && isPlaying == false)
            {
                Debug.Log("touching stove");
                StopCoroutine(fadeOut());
                StartCoroutine(fadeIn());
            }

        }

    IEnumerator fadeIn()
    {
        isPlaying = true;
        ugaliSource.clip = ugaliClip;
        ugaliSource.loop = true;
        ugaliSource.Play();

        while (volume < MaxVol)
        {
            volume += Time.deltaTime / fadeInTime;
            ugaliSource.volume = volume;
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
            ugaliSource.volume = volume;
            yield return new WaitForSeconds(0);
        }

        ugaliSource.volume = 0.0f;
        ugaliSource.Stop();

    }

}