using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class storyAudioTrigger : MonoBehaviour
{
	public AudioMixerSnapshot storySnapshot;
	public float transitionTimeFadeIn = 1.5f;	// duration of fade in

//    public GameObject animation0;
//    public float waitBeforeAnimation0;

    public float waitBeforeVoiceOver;	// wait before starting the voice over clip

	public GameObject animation1;	// bulgogi
	public float startTimeAnimation1;

	public GameObject animation2;	// frying pan
	public float startTimeAnimation2;
	public AudioMixerSnapshot fryingStartsSnapshot;

	public GameObject animation3;	// cutting the meat
	public float startTimeAnimation3;

	public AudioMixerSnapshot fryingFadesSnapshot;	// frying fades to the background
    public float fadeFryingTime;

	public GameObject friendObject;		// friend: "What?"
    public AudioClip friendShockedClip;
    public float startTimeFriendShocked;

	public GameObject animation4;	// scissor
	public float startTimeAnimation4;

	public AudioMixerSnapshot scissorsFadesSnapshot;	// scissors fade to the background
    public float fadeScissorsTime;

	public GameObject animation5;	// Korean BBQ
	public float startTimeAnimation5;


    public AudioClip friendAgreedClip;	// friend: "Aha!"
    public float startTimeFriendAgreed;

//	public GameObject animation6;
//	public float startTimeAnimation6;

	public float startTimeFadeOut;	// story scene fade out starting time
	public AudioMixerSnapshot endStorySnapshot;
	public float transitionTimeFadeOut = 3.0f;	// duration of fade out


	private bool animation0Running = false;
	private bool sound1Running = false;
	private bool sound2Running = false;
	private bool sound3Running = false;
	private bool friendShockedRunning = false;
	private bool sound4Running = false;
	private bool sound5Running = false;
	private bool sound6Running = false;
    private bool friendAgreedRunning = false;
    private bool fadeOutRunning = false;
    private bool fadeFryingRunning = false;


    AudioSource voiceOverAudioSource;
    AudioSource fryingAudioSource;
    AudioSource friendAudioSource;

    void Start()
    {
//		animation0.SetActive(false);
		animation1.SetActive(false);
		animation2.SetActive(false);
		animation3.SetActive(false);
		friendObject.SetActive(false);
		animation4.SetActive(false);
		animation5.SetActive(false);
//		animation6.SetActive(false);

		storySnapshot.TransitionTo(transitionTimeFadeIn);

//        StartCoroutine(playAnimation1());
		StartCoroutine(playVoiceOver());

	}

/*    IEnumerator playAnimation1()
    {
        yield return new WaitForSeconds(waitBeforeFrying);
        animation0.SetActive(true);
        animation0Running = true;
        yield return new WaitForSeconds(0);
    }

	*/

    IEnumerator playVoiceOver()
	{
  	    voiceOverAudioSource = GetComponent<AudioSource>();
		yield return new WaitForSeconds(waitBeforeVoiceOver);
		voiceOverAudioSource.Play();
		print("play");
		yield return new WaitForSeconds(0);
	}


    void Update()
    {


	    if (voiceOverAudioSource.time >= startTimeAnimation1 && voiceOverAudioSource.time < (startTimeAnimation1 + 0.5) && sound1Running == false)
		{
		    animation1.SetActive(true);
		    sound1Running = true;
		}

	    if (voiceOverAudioSource.time >= startTimeAnimation2 && voiceOverAudioSource.time < (startTimeAnimation2 + 0.5) && sound2Running == false)
		{
		    animation2.SetActive(true);
		    sound2Running = true;
			fryingStartsSnapshot.TransitionTo(4.0f);
		}

	    if (voiceOverAudioSource.time >= startTimeAnimation3 && voiceOverAudioSource.time < (startTimeAnimation3 + 0.5) && sound3Running == false)
		{
		    animation3.SetActive(true);
		    sound3Running = true;
		}

		if (voiceOverAudioSource.time >= startTimeFriendShocked && voiceOverAudioSource.time < (startTimeFriendShocked + 0.5) && friendShockedRunning == false)
		{
		    friendObject.SetActive(true);
		    friendShockedRunning = true;
            friendAudioSource = friendObject.GetComponent<AudioSource>();
            friendAudioSource.clip = friendShockedClip;
            friendAudioSource.Play();
        }

        if (voiceOverAudioSource.time >= startTimeAnimation4 && voiceOverAudioSource.time < (startTimeAnimation4 + 0.5) && sound4Running == false)
		{
		    animation4.SetActive(true);
		    sound4Running = true;
		}

	    if (voiceOverAudioSource.time >= startTimeAnimation5 && voiceOverAudioSource.time < (startTimeAnimation5 + 0.5) && sound5Running == false)
		{
	    	animation5.SetActive(true);
		    sound5Running = true;
		}

//		if (voiceOverAudioSource.time >= startTimeAnimation6 && voiceOverAudioSource.time < (startTimeAnimation6 + 0.5) && sound6Running == false)
//		{
//	    	animation6.SetActive(true);
//		    sound6Running = true;
//		}

        if (voiceOverAudioSource.time >= startTimeFriendAgreed && voiceOverAudioSource.time < (startTimeFriendAgreed + 0.5) && friendAgreedRunning == false)
        {
            friendObject.SetActive(true);
            friendAgreedRunning = true;
            friendAudioSource = friendObject.GetComponent<AudioSource>();
            friendAudioSource.clip = friendAgreedClip;
            friendAudioSource.Play();
        }

        if (voiceOverAudioSource.time >= fadeFryingTime && voiceOverAudioSource.time < (fadeFryingTime + 0.5) && fadeFryingRunning == false)
        {
//            fryingAudioSource = animation2.GetComponent<AudioSource>();
//            fryingAudioSource.volume = fryingVolume2;
			fryingFadesSnapshot.TransitionTo(2.0f);
            fadeFryingRunning = true;
        }

        if (voiceOverAudioSource.time >= fadeScissorsTime && voiceOverAudioSource.time < (fadeScissorsTime + 0.5))
		{
			scissorsFadesSnapshot.TransitionTo(3);
		}

        if (voiceOverAudioSource.time >= startTimeFadeOut && voiceOverAudioSource.time < (startTimeFadeOut + 0.5) && fadeOutRunning == false)
		{
			endStorySnapshot.TransitionTo(transitionTimeFadeOut);
            fadeOutRunning = true;
		}
	}

 
}