using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	public AudioClip musicStart;
	public AudioClip musicLoop;

	public float musicVolume;

	private AudioSource audioSource;
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = musicStart;
		audioSource.volume = musicVolume;
		audioSource.loop = false;
        audioSource.Play();
	}
	
	void Update () {
		if (!audioSource.isPlaying)
		{
			audioSource.clip = musicLoop;
			audioSource.volume = musicVolume;
			audioSource.loop = true;
    	    audioSource.Play();
		}

	}
}
