using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class meatScreenAudio : MonoBehaviour
{

    public AudioClip[] screenClips;
    public AudioSource screenSource;

    public void playMeatScreen(float beepNumber)
    {
        int beepNumberInt = (int)beepNumber;
        screenSource.clip = screenClips[beepNumberInt];    // 0 = beep up, 1 = beep down
        screenSource.Play();
        print(beepNumber);
    }

}