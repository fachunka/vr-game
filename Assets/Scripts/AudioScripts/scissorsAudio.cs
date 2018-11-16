using UnityEngine;
using System.Collections;

public class scissorsAudio : MonoBehaviour {

	public AudioClip[] stings;
	public AudioSource stingSource;

	public void callScissorsAudio (string s)
	{
		int randClip = Random.Range (0, stings.Length);
		stingSource.clip = stings[randClip];
		stingSource.Play();
//		Debug.Log ("PrintEvent: " + s + " Called at: " + Time.time);
	}
}
