using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink_cornmeal : MonoBehaviour
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
            if (Mathf.Ceil(Time.fixedTime) % 2 == 0)
            {
                material.EnableKeyword("_EMISSION");
                //material.SetColor("_EmissionColor", Color.green);
                playBeep();
            }
            else
            {
                material.DisableKeyword("_EMISSION");
                //material.SetColor("_EmissionColor", Color.red);
                beepPlaying = false;
            }
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