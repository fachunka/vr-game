using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//if ugali dish and bottle are placed on the table, show particle effect and elevator activates + remove outlines from the storyobject
public class FreeElevatorLevel1 : MonoBehaviour
{
    bool ugaliTouching;
    bool bottleTouching;

    public bool freeAll;
    private bool playOnce;

    public AudioSource helperAudioSource;
    public AudioClip helperAudioClip1;

    // move the lift
    public GameObject lift;

    //change scene
    public string sceneName;
    private float fadeDuration = 1f;
    private SteamVR_TrackedObject trackedObj;

    // Use this for initialization
    void Start()
    {
        ugaliTouching = false;
        bottleTouching = false;
        playOnce = false;
        freeAll = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(helperAudioSource.time);
        //Debug.Log(freeAll);
        //Debug.Log(playOnce);
        //Debug.Log(lift.transform.position.y);


        if (ugaliTouching == true && bottleTouching == true)
        {
            //send bool to particlelauncher
            freeAll = true;
        }

        if (freeAll == true && playOnce == false)
        {
            playOnce = true;
            StartCoroutine(playHelper());


        }

        if (helperAudioSource.time >= 15.5f && freeAll == true)
        {
            Debug.Log("hello");
            FadeToBlack();
            SteamVR_LoadLevel.Begin(sceneName);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ugali")
        {
            ugaliTouching = true;

        }
        if (collision.gameObject.tag == "Bottle")
        {
            bottleTouching = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ugali")
        {
            //print("cornmealTouching");
            ugaliTouching = false;

        }
        if (collision.gameObject.tag == "Bottle")
        {
            bottleTouching = false;
        }
    }

    private void FadeToBlack()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, fadeDuration);

    }

    IEnumerator playHelper()
    {
        helperAudioSource.clip = helperAudioClip1;
        yield return new WaitForSeconds(2);
        helperAudioSource.loop = false;
        helperAudioSource.Play();
        yield return new WaitForSeconds(0);
    }
}
