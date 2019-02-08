using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ugaliStoryAudio : MonoBehaviour
{
	public AudioMixerSnapshot rainSnapshot;
	public float rainFadeInDuration = 1.5f;		// duration of fade in

	public AudioSource thunderSource;
	public AudioClip thunderClip;

	public AudioSource rainSource1;
	public AudioClip rainClip1;

	public AudioSource rainSource2;
	public AudioClip rainClip2;

	public AudioMixerSnapshot rainFadeSnapshot;
	public float rainFadeDownAt = 5.0f;    // rain fade down start time
	public float rainFadeDownDuration = 5.0f;    // rain fade down duration

	public string sceneName;	// next scene
	private float fadeDuration = 1f;
//    private SteamVR_TrackedObject trackedObj;
//    public GameObject gameObContainingScript;

	public float sceneChangeAt = 10.0f;		// time to change the scene

    void Start()
    {
		thunderSource.clip = thunderClip;
		thunderSource.loop = false;
		thunderSource.Play();

		StartCoroutine(playRain());
		rainSnapshot.TransitionTo(rainFadeInDuration);
	}

    IEnumerator playRain()
	{
		rainSource1.clip = rainClip1;
		rainSource1.loop = true;
		rainSource1.Play();

		rainSource2.clip = rainClip2;
		rainSource2.loop = true;
		rainSource2.Play();

		yield return new WaitForSeconds(rainFadeDownAt);
		rainFadeSnapshot.TransitionTo(rainFadeDownDuration);

		yield return new WaitForSeconds(sceneChangeAt);

		FadeToBlack();
		yield return new WaitForSeconds(fadeDuration);
        SteamVR_LoadLevel.Begin(sceneName);
	}

    private void FadeToBlack()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, fadeDuration);
    }

}