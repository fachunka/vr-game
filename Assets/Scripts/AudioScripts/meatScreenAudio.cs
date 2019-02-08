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
            chickenPlayed = false;
            fishPlayed = false; 
        }

        if (beepNumberInt == 2 && chickenPlayed == false)
        {
            screenSource.clip = beepClip;
            screenSource.Play();
            porkPlayed = false;
            chickenPlayed = true;
            fishPlayed = false; 
        }

        if (beepNumberInt == 3 && fishPlayed == false)
        {
            screenSource.clip = beepClip;
            screenSource.Play();
            porkPlayed = false;
            chickenPlayed = false;
            fishPlayed = true;
        }

    }

}