using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StartStoryAudio : MonoBehaviour
{
    public float waitBeforeVideoSound;   // wait before starting the voice over clip

    public AudioSource videoAudioSource;    // where the video audio should emit from
    public AudioClip videoAudioClip;    // audio clip for the video audio

    //Animation objects

    public GameObject animation1;
    

    public GameObject animation2;
    public float startTimeAnimation2;

    public GameObject animation3;
    public float startTimeAnimation3;
    public GameObject animation4;
    public float startTimeAnimation4;
    public GameObject animation5;
    public float startTimeAnimation5;

    //change scene
    public string sceneName;
    private float fadeDuration = 1f;
    private SteamVR_TrackedObject trackedObj;

    void Start()
    {
        StartCoroutine(playVideoSound());
        PlayerPrefs.DeleteAll();
        animation1.SetActive(true);
        animation2.SetActive(false);
        animation3.SetActive(false);
    }


    IEnumerator playVideoSound()
    {
        videoAudioSource.clip = videoAudioClip;
        yield return new WaitForSeconds(waitBeforeVideoSound);
        videoAudioSource.loop = false;
        videoAudioSource.Play();
        yield return new WaitForSeconds(0);
    }


    void Update()
    {
        Debug.Log(videoAudioSource.time);
        FadeToBlack();
        SteamVR_LoadLevel.Begin(sceneName);

        if (videoAudioSource.time >= startTimeAnimation2)
        {
            animation1.SetActive(false);
            animation2.SetActive(true);
        }

        if (videoAudioSource.time >= startTimeAnimation3)
        {
            animation2.SetActive(false);
            animation3.SetActive(true);
        }
        if (videoAudioSource.time >= startTimeAnimation4)
        {
            animation3.SetActive(false);
            animation4.SetActive(true);
        }
        if (videoAudioSource.time >= startTimeAnimation5)
        {
            animation4.SetActive(false);
            animation5.SetActive(true);
        }
        if (videoAudioSource.time >= videoAudioSource.clip.length)
        {
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