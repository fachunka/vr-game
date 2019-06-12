using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class limeStoryAudio : MonoBehaviour
{
    public float waitBeforeVoiceOver;	// wait before starting the voice over clip

	public GameObject animation1;
	public float startTimeAnimation1;

	public GameObject animation2;
	public float startTimeAnimation2;

	public GameObject animation3;
	public float startTimeAnimation3;

	public GameObject animation4;
	public float startTimeAnimation4;

	public float startTimeFadeOut;	// story scene fade out starting time
	public float fadeOutTime = 3.0f;	// duration of fade out


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

	GameObject trafficObject;
	GameObject radioObject;	

    AudioSource voiceOverAudioSource;
	AudioSource trafficSource;
	AudioSource radioSource;

	private float volume = 1.0f;

	public AudioClip exitStorySceneClip;

    //change scene
    public string sceneName;
    private float fadeDuration = 1f;
    private SteamVR_TrackedObject trackedObj;
    public GameObject gameObContainingScript;



    void Start()
    {
		animation1.SetActive(false);
		animation2.SetActive(false);
		animation3.SetActive(false);
		animation4.SetActive(false);

		StartCoroutine(playVoiceOver());

		trafficObject = GameObject.Find("TrafficAudio");
		radioObject = GameObject.Find("RadioAudio");

		trafficSource = trafficObject.GetComponent<AudioSource>();
		radioSource = radioObject.GetComponent<AudioSource>();

	}

    IEnumerator playVoiceOver()
	{
  	    voiceOverAudioSource = GetComponent<AudioSource>();
		yield return new WaitForSeconds(waitBeforeVoiceOver);
		voiceOverAudioSource.Play();

		yield return new WaitForSeconds(startTimeFadeOut);

		StartCoroutine(fadeOut());
	}

	IEnumerator fadeOut()
	{
        while (volume > 0.0f)
        {
            volume -= Time.deltaTime / fadeOutTime;
            trafficSource.volume = volume;
            radioSource.volume = volume;
            yield return new WaitForSeconds(0);
        }

        trafficSource.volume = 0.0f;
        radioSource.volume = 0.0f;

        trafficSource.Stop();
        radioSource.Stop();

		FadeToBlack();

		AudioSource audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = exitStorySceneClip;
		audioSource.Play();

        SteamVR_LoadLevel.Begin(sceneName);
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
		}

	    if (voiceOverAudioSource.time >= startTimeAnimation3 && voiceOverAudioSource.time < (startTimeAnimation3 + 0.5) && sound3Running == false)
		{
		    animation3.SetActive(true);
		    sound3Running = true;
		}

        if (voiceOverAudioSource.time >= startTimeAnimation4 && voiceOverAudioSource.time < (startTimeAnimation4 + 0.5) && sound4Running == false)
		{
		    animation4.SetActive(true);
		    sound4Running = true;
		}

        // if (voiceOverAudioSource.time >= startTimeFadeOut && voiceOverAudioSource.time < (startTimeFadeOut + 0.5) && fadeOutRunning == false)
		// {
		// 	endStorySnapshot.TransitionTo(transitionTimeFadeOut);
        //     fadeOutRunning = true;
        //     FadeToBlack();
        //     SteamVR_LoadLevel.Begin(sceneName);
        // }
	}

    private void FadeToBlack()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, fadeDuration);

    }


}