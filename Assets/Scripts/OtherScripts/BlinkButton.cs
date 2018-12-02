using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkButton : MonoBehaviour
{
    public Material material;

    public bool turnOnBlinkButton;

    public AudioClip beepClip;
    public AudioSource beepSource;
    private bool beepPlaying = false;

    void Start()
    {
        turnOnBlinkButton = false;
        material.DisableKeyword("_EMISSION");

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Mathf.Ceil(Time.fixedTime));
        //Debug.Log(Mathf.Ceil(Time.fixedTime) % 2);

        if (turnOnBlinkButton == true)
        {
            if (Mathf.Ceil(Time.fixedTime) % 2 == 0)
            {
                material.EnableKeyword("_EMISSION");
                playBeep();
            }
            else
            {
                material.DisableKeyword("_EMISSION");
                beepPlaying = false;
            }
        }
    }

    void playBeep()
    {
        if (beepPlaying == false)
        {
            beepSource.clip = beepClip;
            beepSource.loop = false;
            beepSource.Play();
            beepPlaying = true;
        }
    }


}
