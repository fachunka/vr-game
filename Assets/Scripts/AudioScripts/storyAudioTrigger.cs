using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class storyAudioTrigger : MonoBehaviour
{
	public AudioMixerSnapshot storySnapshot;
	public float transitionTimeFadeIn = 1.5f;

    public GameObject fryingObject;
    public float waitBeforeFrying;
    //	public GameObject sound1;

    public float waitBeforeVoiceOver;

	public GameObject animation2;
	public float startTimeSound2;
//	public GameObject sound2;

	public GameObject friendObject;
    public AudioClip friendShockedClip;
    public float startTimeFriendShocked;
    public AudioClip friendAgreedClip;
    public float startTimeFriendAgreed;

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

    public float fadeFryingTime;
    public float fryingVolume2;
	public float startTimeFadeOut;

	public AudioMixerSnapshot endStorySnapshot;
	public float transitionTimeFadeOut = 3.0f;


	private bool fryingRunning = false;
	private bool sound2Running = false;
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
		fryingObject.SetActive(false);
		animation2.SetActive(false);
		friendObject.SetActive(false);
		animation4.SetActive(false);
		animation5.SetActive(false);
		animation6.SetActive(false);

		storySnapshot.TransitionTo(transitionTimeFadeIn);

        StartCoroutine(playAnimation1());
		StartCoroutine(playVoiceOver());

	}

    IEnumerator playAnimation1()
    {
        yield return new WaitForSeconds(waitBeforeFrying);
        fryingObject.SetActive(true);
        fryingRunning = true;
        yield return new WaitForSeconds(0);
    }
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


	    if (voiceOverAudioSource.time >= startTimeSound2 && voiceOverAudioSource.time < (startTimeSound2 + 0.5) && sound2Running == false)
		{
		    animation2.SetActive(true);
		    sound2Running = true;
		}

		if (voiceOverAudioSource.time >= startTimeFriendShocked && voiceOverAudioSource.time < (startTimeFriendShocked + 0.5) && friendShockedRunning == false)
		{
		    friendObject.SetActive(true);
		    friendShockedRunning = true;
            friendAudioSource = friendObject.GetComponent<AudioSource>();
            friendAudioSource.clip = friendShockedClip;
            friendAudioSource.Play();
        }

        if (voiceOverAudioSource.time >= startTimeSound4 && voiceOverAudioSource.time < (startTimeSound4 + 0.5) && sound4Running == false)
		{
		    animation4.SetActive(true);
		    sound4Running = true;
		}

	    if (voiceOverAudioSource.time >= startTimeSound5 && voiceOverAudioSource.time < (startTimeSound5 + 0.5) && sound5Running == false)
		{
	    	animation5.SetActive(true);
		    sound5Running = true;
		}

		if (voiceOverAudioSource.time >= startTimeSound6 && voiceOverAudioSource.time < (startTimeSound6 + 0.5) && sound6Running == false)
		{
	    	animation6.SetActive(true);
		    sound6Running = true;
		}

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
            fryingAudioSource = fryingObject.GetComponent<AudioSource>();
            fryingAudioSource.volume = fryingVolume2;
            fadeFryingRunning = true;
        }

        if (voiceOverAudioSource.time >= startTimeFadeOut && voiceOverAudioSource.time < (startTimeFadeOut + 0.5) && fadeOutRunning == false)
		{
			endStorySnapshot.TransitionTo(transitionTimeFadeOut);
            fadeOutRunning = true;
		}
	}

 
}