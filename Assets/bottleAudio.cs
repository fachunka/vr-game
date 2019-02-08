using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleAudio : MonoBehaviour {

    public AudioClip[] bottleClips;
    private AudioSource audioSource;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Lime" 
        || other.gameObject.tag == "GameController" || other.gameObject.tag == "MainCamera"
        || other.gameObject.tag == "Player")
        {
            // Don't play any sound
        }

        else
		{
            audioSource = gameObject.GetComponent<AudioSource>();
            int randClatter = Random.Range (0, bottleClips.Length);
            audioSource.clip = bottleClips[randClatter];
			audioSource.loop = false;
            audioSource.Play();
		}
	}
}
