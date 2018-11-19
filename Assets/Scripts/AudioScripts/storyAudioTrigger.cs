using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class storyAudioTrigger : MonoBehaviour
{
	public AudioMixerSnapshot storySnapshot;
	public float transitionTimeFadeIn = 1.5f;

	public float waitBeforeVoiceOver;

	public GameObject animation1;
	public float startTimeSound1;
//	public GameObject sound1;


	public GameObject animation2;
	public float startTimeSound2;
//	public GameObject sound2;

	public GameObject animation3;
	public float startTimeSound3;
//	public GameObject sound3;

	public GameObject animation4;
	public float startTimeSound4;
//	public GameObject sound4;

	public GameObject animation5;
	public float startTimeSound5;
//	public GameObject sound5;

	public GameObject animation6;
	public float startTimeSound6;
//	public GameObject sound6;

	public float startTimeFadeOut;

	public AudioMixerSnapshot endStorySnapshot;
	public float transitionTimeFadeOut = 3.0f;


	private bool sound1Running = false;
	private bool sound2Running = false;
	private bool sound3Running = false;
	private bool sound4Running = false;
	private bool sound5Running = false;
	private bool sound6Running = false;
	private bool fadeOutRunning = false;


	AudioSource voiceOver;
	
    void Start()
    {
		animation1.SetActive(false);
		animation2.SetActive(false);
		animation3.SetActive(false);
		animation4.SetActive(false);
		animation5.SetActive(false);
		animation6.SetActive(false);

		storySnapshot.TransitionTo(transitionTimeFadeIn);

		StartCoroutine(playVoiceOver());

	}

	IEnumerator playVoiceOver()
	{
  	    voiceOver = GetComponent<AudioSource>();
		yield return new WaitForSeconds(waitBeforeVoiceOver);
		voiceOver.Play();
		print("play");
		yield return new WaitForSeconds(0);
	}


    void Update()
    {

        if (voiceOver.time >= startTimeSound1 && voiceOver.time < (startTimeSound1 + 0.5) && sound1Running == false)
		{
		animation1.SetActive(true);
		sound1Running = true;
		}

	    if (voiceOver.time >= startTimeSound2 && voiceOver.time < (startTimeSound2 + 0.5) && sound2Running == false)
		{
		animation2.SetActive(true);
		sound2Running = true;
		}

		if (voiceOver.time >= startTimeSound3 && voiceOver.time < (startTimeSound3 + 0.5) && sound3Running == false)
		{
		animation3.SetActive(true);
		sound3Running = true;
		}

	    if (voiceOver.time >= startTimeSound4 && voiceOver.time < (startTimeSound4 + 0.5) && sound4Running == false)
		{
		animation4.SetActive(true);
		sound4Running = true;
		}

	    if (voiceOver.time >= startTimeSound5 && voiceOver.time < (startTimeSound5 + 0.5) && sound5Running == false)
		{
		animation5.SetActive(true);
		sound5Running = true;
		}

		if (voiceOver.time >= startTimeSound6 && voiceOver.time < (startTimeSound6 + 0.5) && sound6Running == false)
		{
		animation6.SetActive(true);
		sound6Running = true;
		}

		if (voiceOver.time >= startTimeFadeOut && voiceOver.time < (startTimeFadeOut + 0.5) && fadeOutRunning == false)
		{
			endStorySnapshot.TransitionTo(transitionTimeFadeOut);
		}
	}

 
}