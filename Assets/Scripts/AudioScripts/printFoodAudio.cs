using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class printFoodAudio : MonoBehaviour {

    public AudioClip printFoodClip;

	private AudioSource audioSource;

	public void playPrintFood()      // this is called from PushButtonFoodDispenser.cs with xxx.SendMessage("playPrintFood");
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        audioSource.clip = printFoodClip;
        audioSource.loop = false;
        audioSource.Play();
    }

}
