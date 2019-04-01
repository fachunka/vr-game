using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink_mirenda : MonoBehaviour
{
    public Material material;

    public bool turnOnBlinkButton;

    private AudioSource audioSource;
    private bool beepPlaying = false;

    void Start()
    {
        turnOnBlinkButton = false;
        material.DisableKeyword("_EMISSION");
        //material.SetColor("_EmissionColor", Color.red);

    }

    // Update is called once per frame
    void Update()
    {
        if (turnOnBlinkButton == true)
        {
                material.EnableKeyword("_EMISSION");
                //material.SetColor("_EmissionColor", Color.green);
                playBeep();
        }
        else if (turnOnBlinkButton == false)
        {
            material.DisableKeyword("_EMISSION");
            //material.SetColor("_EmissionColor", Color.green);
            playBeep();
        }
    }

    void playBeep()
    {
        if (beepPlaying == false)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.loop = false;
            audioSource.Play();
            beepPlaying = true;
        }
    }
}