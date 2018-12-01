using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script for testing in vr machine

public class MonsterSpitObjectNotSim : MonoBehaviour
{
    public GameObject gameObContainingScript;
    public GameObject monsterPlant;

    Vector3 startPosition, driftPosition;
    Vector3 randomPositionFromMonsterPlant;

    Quaternion startRotation, driftRotation;

    public float driftSeconds = 0.3f;
    private float drifterTimer = 0;
    private bool isDrifting = false;
    bool releaseObjectInHand;

    //GameObject inHand;
    //Component[] grabObjects;

    //to restore what object was in hand before colliding with the monsterplant
    public GameObject previousObjectInHand;

    // Use this for initialization
    void Start()
    {
        //ControllerGrabObject ControllerGrabObjectScript = gameObContainingScript.GetComponent<ControllerGrabObject>();

        //if (ControllerGrabObjectScript.objectInHand != null)
        //{
        //    startPosition = ControllerGrabObjectScript.objectInHand.transform.position;
        //    startRotation = ControllerGrabObjectScript.objectInHand.transform.rotation;
        //}

        //setting startpoint as moster plant position to make the code easier
        startPosition = monsterPlant.transform.position;
        startRotation = monsterPlant.transform.rotation;

        randomPositionFromMonsterPlant = new Vector3(0.8f, 0.5f, Random.Range(-0.2f, 0.2f));

        releaseObjectInHand = false;

        //inHand = GameObject.Find("[CameraRig]");
    }

    // Update is called once per frame
    void Update()
    {
        ControllerGrabObject ControllerGrabObjectScript = gameObContainingScript.GetComponent<ControllerGrabObject>();

        //debug
        //Debug.Log(ControllerGrabObjectScript.objectInHand);

        //release the object in hand
        if (releaseObjectInHand == true)
        {
            if (ControllerGrabObjectScript.objectInHand != null)
            {
                //if (ControllerGrabObjectScript.objectInHand)
                //{
                ControllerGrabObjectScript.ReleaseObjectControlledByOtherScript();
                //}

                //restoring the object that was in hand
                previousObjectInHand = ControllerGrabObjectScript.objectInHand;
                Debug.Log(previousObjectInHand);

            }
            releaseObjectInHand = false;
        }

        //return the position
        if (releaseObjectInHand == true)
        {
            StartDrift();
            releaseObjectInHand = false;
        }

        if (isDrifting)
        {
            //if it's greater than the driftSeconds, stop drifting
            drifterTimer += Time.deltaTime;
            if (drifterTimer > driftSeconds)
            {
                StopDrift();
            }

            //another wise drifting
            else
            {
                float ratio = drifterTimer / driftSeconds;

                //should change to object that was in hand
                //ControllerGrabObjectScript.objectInHand.transform.position = Vector3.Lerp(driftPosition, monsterPlant.transform.position + randomPositionFromMonsterPlant, ratio);
                //ControllerGrabObjectScript.objectInHand.transform.rotation = Quaternion.Slerp(driftRotation, startRotation, ratio);

                previousObjectInHand.transform.position = Vector3.Lerp(driftPosition, monsterPlant.transform.position + randomPositionFromMonsterPlant, ratio);
                previousObjectInHand.transform.rotation = Quaternion.Slerp(driftRotation, startRotation, ratio);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if collided except meatchunk, controller, recipescreen, plane, etc. 
        //then spit 
        if (other.gameObject.tag != "MeatChunk" & other.gameObject.tag != "GameController" & other.gameObject.tag != "MainCamera" & other.gameObject.tag != "RecipeScreen" & other.gameObject.tag != "Plane")
        {
            Debug.Log("Something wrong feeded");
            releaseObjectInHand = true;
        }

    }

    private void StartDrift()
    {
        isDrifting = true;
        drifterTimer = 0;

        driftPosition = monsterPlant.transform.position;
        driftRotation = monsterPlant.transform.rotation;

        Rigidbody rb = previousObjectInHand.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }


    private void StopDrift()
    {
        isDrifting = false;

        previousObjectInHand.transform.position = monsterPlant.transform.position + randomPositionFromMonsterPlant;
        previousObjectInHand.transform.rotation = startRotation;

        Rigidbody rb = previousObjectInHand.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
