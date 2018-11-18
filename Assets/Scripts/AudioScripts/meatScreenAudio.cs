using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class meatScreenAudio : MonoBehaviour
{

    public AudioClip beepPork;
    public AudioClip beepChicken;
    public AudioSource screenSource;

    private int beepNumberInt = 0;
    private bool porkPlayed = false;
    private bool chickenPlayed = false;

    public void playMeatScreen(float beepNumber)
    {
        beepNumberInt = (int)beepNumber;

        if (beepNumberInt == 1 && porkPlayed == false)
        {
            screenSource.clip = beepPork;
            screenSource.Play();
            porkPlayed = true;
            chickenPlayed = false;
        }

        if (beepNumberInt == 2 && chickenPlayed == false)
        {
            screenSource.clip = beepChicken;
            screenSource.Play();
            chickenPlayed = true;
            porkPlayed = false;
        }

    }

}