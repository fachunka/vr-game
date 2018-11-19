using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class monsterPlantAudio : MonoBehaviour
{

    public AudioClip[] spitClips;
    public AudioSource spitSource;

    public void playSpit()
    {
        int randSpit = Random.Range (0, spitClips.Length);
        spitSource.clip = spitClips[randSpit];
        spitSource.Play();
    }

    
}