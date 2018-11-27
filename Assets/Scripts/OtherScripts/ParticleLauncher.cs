using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
    public GameObject gameObContainingScript;
    public ParticleSystem particleLauncher;

    bool turnedOnParticle;

    // Use this for initialization
    void Start()
    {
        turnedOnParticle = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TurnOnParticle()
    {
            print("particle effect activated");
            particleLauncher.Play();
    }
}
