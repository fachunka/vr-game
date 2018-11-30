using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
    public GameObject gameObContainingScript;
    public ParticleSystem particleLauncher;

    bool stopParticle;

    // Use this for initialization
    void Start()
    {
        stopParticle = true;
    }

    // Update is called once per frame
    void Update()
    {
        FreeElevatorLevel1 FreeElevatorLevel1Script = gameObContainingScript.GetComponent<FreeElevatorLevel1>();

        if(FreeElevatorLevel1Script.freeAll == true)
        {
            if (stopParticle == true)
            {
                TurnOnParticle();
                stopParticle = false;
            }
        }

       else if (FreeElevatorLevel1Script.freeAll == false)
        {
            if (stopParticle == false)
            {
                TurnOnParticle();
                stopParticle = true;
            }
        }

    }

    void TurnOnParticle()
    {
            print("particle effect activated");
            particleLauncher.Play();
    }

    void TurnOffParticle()
    {
        print("particle effect activated");
        particleLauncher.Stop();
    }


}
