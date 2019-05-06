using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StartStoryAudio : MonoBehaviour
{
    public AudioMixerSnapshot storySnapshot;
    public float transitionTimeFadeIn = 1.5f;   // duration of fade in


    public float waitBeforeVoiceOver;   // wait before starting the voice over clip

    public float startTimeAnimation1;

    public float startTimeAnimation2;
    public AudioMixerSnapshot fryingStartsSnapshot;

    public float startTimeAnimation3;

    public AudioMixerSnapshot fryingFadesSnapshot;	// frying fades to the background
    public float fadeFryingTime;

    public AudioClip friendShockedClip;
    public float startTimeFriendShocked;

    public float startTimeAnimation4;

    public AudioMixerSnapshot scissorsFadesSnapshot;	// scissors fade to the background
    public float fadeScissorsTime;

    public float startTimeAnimation5;


    public AudioClip friendAgreedClip;	// friend: "Aha!"
    public float startTimeFriendAgreed;

    public float startTimeFadeOut;  // story scene fade out starting time
    public AudioMixerSnapshot endStorySnapshot;
    public float transitionTimeFadeOut = 3.0f;  // duration of fade out


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

    //change scene
    public string sceneName;
    private float fadeDuration = 1f;
    private SteamVR_TrackedObject trackedObj;

    void Start()
    {



        storySnapshot.TransitionTo(transitionTimeFadeIn);

        StartCoroutine(playVoiceOver());
        PlayerPrefs.DeleteAll();


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


        if (voiceOverAudioSource.time >= startTimeAnimation1 && voiceOverAudioSource.time < (startTimeAnimation1 + 0.5) && sound1Running == false)
        {
            sound1Running = true;
        }

        if (voiceOverAudioSource.time >= startTimeAnimation2 && voiceOverAudioSource.time < (startTimeAnimation2 + 0.5) && sound2Running == false)
        {
            sound2Running = true;
            fryingStartsSnapshot.TransitionTo(4.0f);
        }

        if (voiceOverAudioSource.time >= startTimeAnimation3 && voiceOverAudioSource.time < (startTimeAnimation3 + 0.5) && sound3Running == false)
        {
            sound3Running = true;
        }

        if (voiceOverAudioSource.time >= startTimeFriendShocked && voiceOverAudioSource.time < (startTimeFriendShocked + 0.5) && friendShockedRunning == false)
        {
            friendShockedRunning = true;
            friendAudioSource.clip = friendShockedClip;
            friendAudioSource.Play();
        }

        if (voiceOverAudioSource.time >= startTimeAnimation4 && voiceOverAudioSource.time < (startTimeAnimation4 + 0.5) && sound4Running == false)
        {
            sound4Running = true;
        }

        if (voiceOverAudioSource.time >= startTimeAnimation5 && voiceOverAudioSource.time < (startTimeAnimation5 + 0.5) && sound5Running == false)
        {
            sound5Running = true;
        }

        if (voiceOverAudioSource.time >= startTimeFriendAgreed && voiceOverAudioSource.time < (startTimeFriendAgreed + 0.5) && friendAgreedRunning == false)
        {
            friendAgreedRunning = true;
            friendAudioSource.clip = friendAgreedClip;
            friendAudioSource.Play();
        }

        if (voiceOverAudioSource.time >= fadeFryingTime && voiceOverAudioSource.time < (fadeFryingTime + 0.5) && fadeFryingRunning == false)
        {
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
            FadeToBlack();
            SteamVR_LoadLevel.Begin(sceneName);
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