using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class meatScreenAudio : MonoBehaviour
{

    public AudioClip beepClip;
    public AudioSource screenSource;

    private int beepNumberInt = 0;
    private bool porkPlayed = false;
    private bool chickenPlayed = false;
    private bool fishPlayed = false;

    public void playMeatScreen(float beepNumber)        // receives beepNumber float (SendMessage) from changeFoodDispenserCategory.cs script
    {
        beepNumberInt = (int)beepNumber;
 
        if (beepNumberInt == 1 && porkPlayed == false)
        {
            screenSource.clip = beepClip;
            screenSource.Play();
            porkPlayed = true;
            Debug.Log("play pork beep");
        }

        if (beepNumberInt == 2 && chickenPlayed == false)
        {
            screenSource.clip = beepClip;
            screenSource.Play();
            chickenPlayed = true;
            Debug.Log("play chicken beep");
        }

        if (beepNumberInt == 3 && fishPlayed == false)
        {
            screenSource.clip = beepClip;
            screenSource.Play();
            fishPlayed = true;
            Debug.Log("play fish beep");
        }

    }

}