using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ugaliStoryAudio : MonoBehaviour
{
	public AudioSource thunderSource;
	public AudioClip thunderClip;

	public AudioSource rainSource1;
	public AudioClip rainClip1;

	public AudioSource rainSource2;
	public AudioClip rainClip2;

	public AudioSource rainSource3;
	public AudioClip rainClip3;

	public float waitBeforeVO = 7.0F;
	
	public AudioSource voiceOverSource;
	public AudioClip voiceOverClip;

	private float volume = 1.0f;

	public float startTimeFadeOut;	// story scene fade out starting time
	public float fadeOutTime = 3.0f;	// duration of fade out


	public string sceneName;	// next scene
	private float fadeDuration = 1f;
//    private SteamVR_TrackedObject trackedObj;
//    public GameObject gameObContainingScript;

	public GameObject animation1;
	public GameObject animation2;

	public float showAnimation1;	// time to show first animation (relative to voice over playback time)
	public float showAnimation2;	// time to show second animation (relative to voice over playback time)

    private bool fadeOutRunning = false;

	public AudioClip exitStorySceneClip;


    void Start()
    {
		animation1.SetActive(false);
		animation2.SetActive(false);

		thunderSource.clip = thunderClip;
		thunderSource.loop = false;
		thunderSource.Play();

		StartCoroutine(playRain());

		StartCoroutine(playVoiceOver());
	}

    IEnumerator playRain()
	{
		rainSource1.clip = rainClip1;
		rainSource1.loop = true;
		rainSource1.Play();

		rainSource2.clip = rainClip2;
		rainSource2.loop = true;
		rainSource2.Play();

		rainSource3.clip = rainClip3;
		rainSource3.loop = true;
		rainSource3.Play();

		yield return new WaitForSeconds(startTimeFadeOut);
		StartCoroutine(fadeOut());
	}
	
	IEnumerator playVoiceOver()
	{
		yield return new WaitForSeconds(waitBeforeVO);
		voiceOverSource.clip = voiceOverClip;
		voiceOverSource.loop = false;
		voiceOverSource.Play();
	}

  IEnumerator fadeOut()
    {
        while (volume > 0.0f)
        {
            volume -= Time.deltaTime / fadeOutTime;
            rainSource1.volume = volume;
            rainSource2.volume = volume;
            rainSource3.volume = volume;
			voiceOverSource.volume = volume;
            yield return new WaitForSeconds(0);
        }

        rainSource1.volume = 0.0f;
        rainSource2.volume = 0.0f;
        rainSource3.volume = 0.0f;
		voiceOverSource.volume = 0.0f;

        rainSource1.Stop();
        rainSource2.Stop();
        rainSource3.Stop();
		voiceOverSource.Stop();

		FadeToBlack();

		AudioSource audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = exitStorySceneClip;
		audioSource.Play();

        SteamVR_LoadLevel.Begin(sceneName);
    }

	void Update ()
	{
		if (voiceOverSource.time >= showAnimation1 && voiceOverSource.time < (showAnimation1 + 0.5))
		{
			animation1.SetActive(true);
		}

		if (voiceOverSource.time >= showAnimation2 && voiceOverSource.time < (showAnimation2 + 0.5))
		{
			animation2.SetActive(true);
		}

		// if (voiceOverSource.time >= startTimeFadeOut && voiceOverSource.time < (startTimeFadeOut + 0.5) && fadeOutRunning == false)
		// {
		// 	print("HEP!");
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