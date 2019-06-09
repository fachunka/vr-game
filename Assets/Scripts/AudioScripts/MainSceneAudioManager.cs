using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainSceneAudioManager : MonoBehaviour {

	public AudioMixerSnapshot puzzleSnapshot;
	
	void Start ()
	{
		puzzleSnapshot.TransitionTo(1);
	}
	
}
