using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class monsterPlantAudio : MonoBehaviour
{

    public AudioClip breathingClip;
    public float breathingVolume = 0.5f;
    public AudioClip[] spitClips;
    public float spittingVolume = 1.0f;
    public AudioClip eatingClip;
    public float eatingVolume = 1.0f;
    public AudioClip sleepingClip;
    public float sleepingVolume = 0.5f;

    private bool isShrinked = false;

    private AudioSource audioSource;

    void Start ()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = breathingClip;
        audioSource.loop = true;
        audioSource.volume = breathingVolume;
        audioSource.Play();
    }

    void Update ()
    {
        if (!audioSource.isPlaying && isShrinked == false)
        {
            print("back to breathing");
            audioSource.clip = breathingClip;
            audioSource.loop = true;
            audioSource.volume = breathingVolume;
            audioSource.Play();
        }

        if (!audioSource.isPlaying && isShrinked == true)
        {
            print("to sleeping");
            audioSource.clip = sleepingClip;
            audioSource.loop = true;
            audioSource.volume = sleepingVolume;
            audioSource.Play();
        }

    }

    public void playSpit()      // this is called from MonsterSpitObject.cs with gameObject.SendMessage("playSpit");
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        int randSpit = Random.Range (0, spitClips.Length);
        audioSource.clip = spitClips[randSpit];
        audioSource.loop = false;
        audioSource.volume = spittingVolume;
        audioSource.Play();
    }

    public void playEating()    // this is called from MonsterPlantResize.cs with gameObject.SendMessage("playSpit");
    {
        isShrinked = true;

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = eatingClip;
        audioSource.loop = false;
        audioSource.volume = eatingVolume;
        audioSource.Play();
    }

}