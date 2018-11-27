using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//if ugali dish and bottle are placed on the table, show particle effect and elevator activates + remove outlines from the storyobject
public class FreeElevatorLevel1 : MonoBehaviour
{
    bool ugaliTouching;
    bool bottleTouching;

    public bool freeAll;

    bool stopParticle;

    public ParticleSystem particleLauncher;

    // Use this for initialization
    void Start()
    {
        ugaliTouching = false;
        bottleTouching = false;

        freeAll = false;
        stopParticle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ugaliTouching == true && bottleTouching == true)
        {
            if (stopParticle == true)
            { 
            //print("particle effect activated");

            //send bool to particlelauncher
            freeAll = true;

            TurnOnParticle();
            stopParticle = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ugali")
        {
            //print("cornmealTouching");
            ugaliTouching = true;

        }
        if (collision.gameObject.tag == "Bottle")
        {
            bottleTouching = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ugali")
        {
            //print("cornmealTouching");
            ugaliTouching = false;

        }
        if (collision.gameObject.tag == "Bottle")
        {
            bottleTouching = false;
        }
    }

    void TurnOnParticle()
    {
        print("particle effect activated");
        particleLauncher.Play();
    }
}
