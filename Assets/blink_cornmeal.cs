using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink_cornmeal : MonoBehaviour
{
    public Material material;

    public bool turnOnBlinkButton;

    public AudioClip greenBeep;
    public AudioClip redBeep;
    
    private AudioSource audioSource;
    private bool greenBeepPlaying = false;
    private bool redBeepPlaying = false;

    void Start()
    {
        turnOnBlinkButton = false;
        material.DisableKeyword("_EMISSION");
        material.SetColor("_EmissionColor", Color.red);

    }

    // Update is called once per frame
    void Update()
    {
        if (turnOnBlinkButton == true)
        {

            material.EnableKeyword("_EMISSION");
            material.SetColor("_EmissionColor", Color.green);
            playGreenBeep();
            redBeepPlaying = false;
        }
        else if (turnOnBlinkButton == false)
        {
            material.DisableKeyword("_EMISSION");
            material.SetColor("_EmissionColor", Color.green);
            playRedBeep();
            greenBeepPlaying = false;
        }
    }

    void playGreenBeep()
    {
        if (greenBeepPlaying == false)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = greenBeep;
            audioSource.loop = false;
            audioSource.Play();
            greenBeepPlaying = true;
        }
    }

    void playRedBeep()
    {
        if (redBeepPlaying == false)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = redBeep;
            audioSource.loop = false;
            audioSource.Play();
            redBeepPlaying = true;
        }
    }
}