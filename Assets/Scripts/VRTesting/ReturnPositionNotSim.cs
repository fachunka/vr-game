﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//tutorial: https://www.youtube.com/watch?v=0Tpm0AyUQQU
//script for testing in vr machine

public class ReturnPositionNotSim : MonoBehaviour
{
    public GameObject[] gameObContainingScript;

    Vector3 startPosition, driftPosition;
    Quaternion startRotation, driftRotation;

    public float driftSeconds = 0.3f;
    private float drifterTimer = 0;
    private bool isDrifting = false;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    //storyobject going back to its original position when thrown back
    void Update()
    {
        //get script from "ControllerGrabObject" script
        //have to get data from both right and left hand
        ControllerGrabObject ControllerGrabObjectScript = gameObContainingScript[0].GetComponent<ControllerGrabObject>();

        //if game object is released, startdrift
        //get the boolean 'releasedObject' from 'ControllerGrabObject' script
        if (/*Input.GetKeyDown("r") || */ControllerGrabObjectScript.releasedObject == true )
        {
            StartDrift();
            ControllerGrabObjectScript.releasedObject = false;
        }

        if (isDrifting)
        {
            drifterTimer += Time.deltaTime;
            if (drifterTimer > driftSeconds)
            {
                StopDrift();
            }
            else
            {
                float ratio = drifterTimer / driftSeconds;
                transform.position = Vector3.Lerp(driftPosition, startPosition, ratio);
                transform.rotation = Quaternion.Slerp(driftRotation, startRotation, ratio);
            }
        }
    }

    private void StartDrift()
    {
        isDrifting = true;
        drifterTimer = 0;

        driftPosition = transform.position;
        driftRotation = transform.rotation;

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }


    private void StopDrift()
    {
        isDrifting = false;
        transform.position = startPosition;
        transform.rotation = startRotation;

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
