﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject gameObContainingScript;
    private int BoxKey;
    private bool destroyed = false;
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;

    }

    void Update()
    {

        BoxKey = PlayerPrefs.GetInt("BoxKey");


        ControllerGrabObject deleteObjectInHand = gameObContainingScript.GetComponent<ControllerGrabObject>();

        //Debug.Log(deleteObjectInHand.objectInHand);
        //Debug.Log(deleteObjectInHand.collidingObject);

        if (BoxKey == 1)
        {
            //print("Key destroyed?");
            //Destroy(this.gameObject);
            rend.enabled = false;

        }

        //if (BoxKey == 1 && destroyed == false)
        //{
        //    destroyed = true;
        //    deleteObjectInHand.objectInHand = null;
        //    deleteObjectInHand.collidingObject = null;
        //    deleteObjectInHand.onTriggerEnterActivated = false;
        //    deleteObjectInHand.releasedObject = true;
        //}



    }

}
