using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StartStoryAudio : MonoBehaviour
{
    public float waitBeforeVideoSound;   // wait before starting the voice over clip

    public AudioSource videoAudioSource;    // where the video audio should emit from
    public AudioClip videoAudioClip;    // audio clip for the video audio

    //change scene
    public string sceneName;
    private float fadeDuration = 1f;
    private SteamVR_TrackedObject trackedObj;

    void Start()
    {
        StartCoroutine(playVideoSound());
        PlayerPrefs.DeleteAll();
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