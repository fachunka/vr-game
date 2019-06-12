using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class storyAudioTrigger : MonoBehaviour
{
	public float fadeInTime = 1.5f;	// duration of fade in

    public float waitBeforeVoiceOver;	// wait before starting the voice over clip

	public GameObject animation1;	// bulgogi
	public float startTimeAnimation1;

	public GameObject animation2;	// frying pan
	public float startTimeAnimation2;

	public GameObject animation3;	// cutting the meat
	public float startTimeAnimation3;

    public float fadeFryingTime;
	public float fryingVolume = 0.45f;
	public float fryingEndVolume = 0.1f;

	public GameObject friendObject;		// friend: "What?"
    public AudioClip friendShockedClip;
    public float startTimeFriendShocked;

	public GameObject animation4;	// scissor
	public float startTimeAnimation4;

	public GameObject animation5;	// Korean BBQ
	public float startTimeAnimation5;


    public AudioClip friendAgreedClip;	// friend: "Aha!"
    public float startTimeFriendAgreed;

	public float startTimeFadeOut;	// story scene fade out starting time
	public float fadeOutTime = 3.0f;	// duration of fade out

	private GameObject party1;
	private GameObject party2;
	private GameObject party3;


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
    AudioSource cuttingAudioSource;

	AudioSource party1Source;
	AudioSource party2Source;
	AudioSource party3Source;

	public AudioClip exitStorySceneClip;


    //change scene
    public string sceneName;
    private float fadeDuration = 1f;
    private SteamVR_TrackedObject trackedObj;
    public GameObject gameObContainingScript;

	private float partyVolume = 0.0f;
    private float MaxVol = 1.0f;

	private float cuttingVolume = 1.0f;

    void Start()
    {

		animation1.SetActive(false);
		animation2.SetActive(false);
		animation3.SetActive(false);
		friendObject.SetActive(false);
		animation4.SetActive(false);
		animation5.SetActive(false);

		party1 = GameObject.Find("PartyAudio1");
		party2 = GameObject.Find("PartyAudio2");
		party3 = GameObject.Find("PartyAudio3");

		party1Source = party1.GetComponent<AudioSource>();
		party2Source = party2.GetComponent<AudioSource>();
		party3Source = party3.GetComponent<AudioSource>();

		fryingAudioSource = animation2.GetComponent<AudioSource>();
		cuttingAudioSource = animation4.GetComponent<AudioSource>();

		StartCoroutine(fadeIn());

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

    IEnumerator fadeIn()
    {
        while (partyVolume < MaxVol)
        {
            partyVolume += Time.deltaTime / fadeInTime;
			party1Source.volume = partyVolume;
			party2Source.volume = partyVolume;
			party3Source.volume = partyVolume;
            yield return new WaitForSeconds(0);
        }
    }


    IEnumerator playVoiceOver()
	{
  	    voiceOverAudioSource = GetComponent<AudioSource>();
		yield return new WaitForSeconds(waitBeforeVoiceOver);
		voiceOverAudioSource.Play();
		yield return new WaitForSeconds(0);
	}

IEnumerator fadeFrying()
    {
        while (fryingVolume > fryingEndVolume)
        {
            fryingVolume -= Time.deltaTime / fadeFryingTime;
            fryingAudioSource.volume = fryingVolume;
            yield return new WaitForSeconds(0);
        }
    }

IEnumerator fadeOutParty()
    {
        while (partyVolume > 0.0f)
        {
            partyVolume -= Time.deltaTime / fadeOutTime;
			party1Source.volume = partyVolume;
			party2Source.volume = partyVolume;
			party3Source.volume = partyVolume;
            yield return new WaitForSeconds(0);
        }

        party1Source.Stop();
        party2Source.Stop();
        party3Source.Stop();

		FadeToBlack();

		AudioSource audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = exitStorySceneClip;
		audioSource.Play();

        SteamVR_LoadLevel.Begin(sceneName);
    }

IEnumerator fadeOutFrying()
    {
        while (fryingVolume > 0.0f)
        {
            fryingVolume -= Time.deltaTime / fadeOutTime;
			fryingAudioSource.volume = fryingVolume;
            yield return new WaitForSeconds(0);
        }

        fryingAudioSource.Stop();
    }

IEnumerator fadeOutCutting()
	{
		while (cuttingVolume > 0.0f)
		{
			cuttingVolume -= Time.deltaTime / fadeOutTime;
			cuttingAudioSource.volume = cuttingVolume;
			yield return new WaitForSeconds(0);
		}

		cuttingAudioSource.Stop();
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
			StartCoroutine(fadeFrying());

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
            fadeFryingRunning = true;
        }


        if (voiceOverAudioSource.time >= startTimeFadeOut && voiceOverAudioSource.time < (startTimeFadeOut + 0.5) && fadeOutRunning == false)
		{
			StartCoroutine(fadeOutParty());
			StartCoroutine(fadeOutFrying());
			StartCoroutine(fadeOutCutting());
			// endStorySnapshot.TransitionTo(transitionTimeFadeOut);
            fadeOutRunning = true;
            // FadeToBlack();
            // SteamVR_LoadLevel.Begin(sceneName);
        }
	}

    private void FadeToBlack()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, fadeDuration);

    }


}