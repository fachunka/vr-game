using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class fadeAudioIn : MonoBehaviour {

//    public AudioClip audioClip;
//    public AudioSource audioSource;
//	public float MaxVol = 1.0f;
//    public float fadeInTime = 1.0f;

//    private float volume = 0.0f;

    AudioSource audio1;

	void Start () {
        audio1 = GetComponent<AudioSource>();
//		audio1.volume = 0.0f;
        audio1.Play();
        print("play sizzle");
//		StartCoroutine(fadeIn());
	}
/*	
    IEnumerator fadeIn()
    {
        audio1.Play();
        print("start fade");

        while (volume < MaxVol)
        {
            volume += Time.deltaTime / fadeInTime;
            audio1.volume = volume;
            print(volume);
            yield return new WaitForSeconds(0);
        }
    }

    */
}
