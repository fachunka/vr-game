using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class vegiScreenAudio : MonoBehaviour
{

    public AudioClip beepClip;
    public AudioSource screenSource;

    private int beepNumberInt = 0;
    private bool limePlayed = false;
    private bool cornmealPlayed = false;
    private bool mirendaPlayed = false;
    private bool bananaPlayed = false;

    public void playVegiScreen(float beepNumber)        // receives beepNumber float (SendMessage) from changeFoodDispenserCategoryVeg.cs script
    {
        beepNumberInt = (int)beepNumber;
 
        if (beepNumberInt == 1 && limePlayed == false)
        {
            screenSource.clip = beepClip;
            screenSource.Play();
            limePlayed = true;
            cornmealPlayed = false;
            mirendaPlayed = false; 
            bananaPlayed = false; 
        }

        if (beepNumberInt == 2 && cornmealPlayed == false)
        {
            screenSource.clip = beepClip;
            screenSource.Play();
            limePlayed = false;
            cornmealPlayed = true;
            mirendaPlayed = false; 
            bananaPlayed = false; 
        }

        if (beepNumberInt == 3 && mirendaPlayed == false)
        {
            screenSource.clip = beepClip;
            screenSource.Play();
            limePlayed = false;
            cornmealPlayed = false;
            mirendaPlayed = true; 
            bananaPlayed = false; 
        }

        if (beepNumberInt == 4 && bananaPlayed == false)
        {
            screenSource.clip = beepClip;
            screenSource.Play();
            limePlayed = false;
            cornmealPlayed = false;
            mirendaPlayed = false; 
            bananaPlayed = true; 
        }

    }

}