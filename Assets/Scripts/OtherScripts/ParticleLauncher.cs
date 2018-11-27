﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
    public GameObject gameObContainingScript;
    public ParticleSystem particleLauncher;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FreeElevatorLevel1 FreeElevatorLevel1Script = gameObContainingScript.GetComponent<FreeElevatorLevel1>();

        if (FreeElevatorLevel1Script.freeAll == true || Input.GetKeyDown("p"))
        {
            particleLauncher.Play();
            FreeElevatorLevel1Script.freeAll = false;
        }
    }
}