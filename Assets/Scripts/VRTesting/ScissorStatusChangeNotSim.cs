﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScissorStatusChangeNotSim : MonoBehaviour
{

    private GameObject rightHand;
    public GameObject animateScissors;

    //Current Object Name
    private string currentObj;

    //Player Location
    private Vector3 loc;

    //Bools
    private bool inHand;
    private bool triggerEnteredAnimateScissors;
    public bool letGoInAnimateScissors;

    void Start()
    {
        //Object
        rightHand = this.gameObject;
        currentObj = "null";

        //Bools
        inHand = false;
        triggerEnteredAnimateScissors = false;
        letGoInAnimateScissors = false;
    }

    void Update()
    {
        loc = rightHand.transform.localPosition;
        //Debug.Log(rightHand.gameObject.transform.childCount);
        if (rightHand.gameObject.transform.childCount == 2)
        {
            currentObj = rightHand.gameObject.transform.GetChild(1).gameObject.name;
            //Debug.Log(currentObj);
        }

        //animate scissors pickup
        if (triggerEnteredAnimateScissors == true)
        {
            if(currentObj == "ScissorsInanimate")
            {
                Debug.Log("Grabbing ScissorsInaimate and trying to change the status of scissors");
                if (rightHand.gameObject.transform.childCount == 1)
                {
                animateScissors.transform.parent = rightHand.transform;
                animateScissors.transform.localPosition = Vector3.zero;
                //                Reset(key);
                animateScissors.transform.rotation = Quaternion.Euler(0, 90, 0);
                animateScissors.GetComponent<Rigidbody>().velocity = Vector3.zero;
                animateScissors.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

                animateScissors.GetComponent<Rigidbody>().useGravity = true;
                animateScissors.GetComponent<BoxCollider>().isTrigger = true;

                inHand = true;
                }
            }
        }

        //bool to drop inanimate scissors(passed to PickupJNotSim script)
        if (currentObj == "ScissorsInanimate" && triggerEnteredAnimateScissors == true /*&& rightHand.gameObject.transform.childCount == 2*/)
        {
            Debug.Log("let go scissors(bool)");
            letGoInAnimateScissors = true;
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "ScissorAnimateTrigger")
        {
            Debug.Log("touching Scissor Animate Trigge Object");
            triggerEnteredAnimateScissors = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        // We reset this variable since character is no longer in the trigger
        // meat chunk trigger
        if (col.tag == "ScissorAnimateTrigger")
        {
            Debug.Log("not touching Scissor Animate Trigge Object");
            triggerEnteredAnimateScissors = false;
        }
    }


}
 