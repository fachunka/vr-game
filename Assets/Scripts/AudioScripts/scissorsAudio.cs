using UnityEngine;
using System.Collections;

public class scissorsAudio : MonoBehaviour {

	public AudioClip[] scissorClips;
	public AudioSource scissorSource;

	public void callScissorsAudio (string s)
	{
		int randScissor = Random.Range (0, scissorClips.Length);
		scissorSource.clip = scissorClips[randScissor];
		scissorSource.Play();
		print("scissor audio clip");
	}
}
