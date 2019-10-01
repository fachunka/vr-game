using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftSceneAudioManager : MonoBehaviour
{

    public float waitBeforeHelperVoice;

    public AudioSource helperAudioSource;
    public AudioClip helperAudioClip1;
    public AudioClip helperAudioClip2;
    public AudioClip helperAudioClip3;

    private GameObject elevatorAudio1;
    private GameObject elevatorAudio2;
    private AudioSource elevatorSource1;
    private AudioSource elevatorSource2;

    public AudioClip elevatorStartClip1;
    public AudioClip elevatorStartClip2;

    public AudioClip elevatorStopClip1;
    public AudioClip elevatorStopClip2;

    public GameObject gameObContainingScript;

    private bool clip1Played = false;
    private bool helper3isPlaying = false;
    private bool liftHasStopped = false;
    private bool endOfClip1 = false;

    public string sceneName;
    private float fadeDuration = 1f;
    private SteamVR_TrackedObject trackedObj;

    void Start()
    {
        StartCoroutine(playHelper());

        elevatorAudio1 = GameObject.Find("ElevatorAudio1");
        elevatorAudio2 = GameObject.Find("ElevatorAudio2");

        elevatorSource1 = elevatorAudio1.GetComponent<AudioSource>();
        elevatorSource2 = elevatorAudio2.GetComponent<AudioSource>();

        elevatorSource1.clip = elevatorStartClip1;
        elevatorSource2.clip = elevatorStartClip2;

        elevatorSource1.Play();
        elevatorSource2.Play();
    }


    IEnumerator playHelper()
    {
        helperAudioSource.clip = helperAudioClip1;
        yield return new WaitForSeconds(waitBeforeHelperVoice);
        helperAudioSource.loop = false;
        helperAudioSource.Play();
        yield return new WaitForSeconds(0);
    }

    void Update()
    {
        //Debug.Log(helperAudioSource.time);
        //Debug.Log(liftHasStopped);
        // Bring from another script if lift is moving or not
        if (gameObContainingScript)
        {
            changePos LiftStopScript = gameObContainingScript.GetComponent<changePos>();

            if (LiftStopScript.liftMoving == false)
            {
                liftHasStopped = true;
            }
            else {
                liftHasStopped = false;
            }
        }

        // Change boolean when audio clip is played
        if (helperAudioSource.time >= (helperAudioSource.clip.length - 0.5)) {
            endOfClip1 = true;
        }


        // Play the second audio clip
        if (endOfClip1 == true && !clip1Played && !helper3isPlaying && liftHasStopped == true)
        {
            clip1Played = true;
            elevatorSource1.clip = elevatorStopClip1;
            elevatorSource2.clip = elevatorStopClip2;

            elevatorSource1.Play();
            elevatorSource2.Play();

            StartCoroutine(playHelper2());
        }
          
        // Play the ending audio
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(playHelper3());
            helper3isPlaying = true;
        }

        if (helperAudioSource.time >= 7.0f && helperAudioSource.time < 7.05f && helper3isPlaying == true)
        {
            elevatorSource1.clip = elevatorStartClip1;
            elevatorSource2.clip = elevatorStartClip2;

            elevatorSource1.Play();
            elevatorSource2.Play();
        }
        if (helperAudioSource.time >= 21.5f && liftHasStopped == true)
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

    IEnumerator playHelper2()
    {
        helperAudioSource.clip = helperAudioClip2;
        yield return new WaitForSeconds(2);
        helperAudioSource.loop = false;
        helperAudioSource.Play();
        yield return new WaitForSeconds(0);
    }

    IEnumerator playHelper3()
    {
        helperAudioSource.clip = helperAudioClip3;
        yield return new WaitForSeconds(0);
        helperAudioSource.loop = false;
        helperAudioSource.Play();
        yield return new WaitForSeconds(0);
    }

}
