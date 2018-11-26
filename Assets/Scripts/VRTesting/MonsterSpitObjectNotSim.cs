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

    GameObject inHand;
    Component[] grabObjects;

    // Use this for initialization
    void Start()
    {
        ControllerGrabObject ControllerGrabObjectScript = gameObContainingScript.GetComponent<ControllerGrabObject>();

        if (ControllerGrabObjectScript.objectInHand != null)
        {
            startPosition = ControllerGrabObjectScript.objectInHand.transform.position;
            startRotation = ControllerGrabObjectScript.objectInHand.transform.rotation;
        }

        randomPositionFromMonsterPlant = new Vector3(0.8f, 0.5f, Random.Range(-0.2f, 0.2f));

        releaseObjectInHand = false;

        inHand = GameObject.Find("[CameraRig]");
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
            drifterTimer += Time.deltaTime;
            if (drifterTimer > driftSeconds)
            {
                StopDrift();
            }
            else
            {
                float ratio = drifterTimer / driftSeconds;

                //should change to object that was in hand
                ControllerGrabObjectScript.objectInHand.transform.position = Vector3.Lerp(driftPosition, monsterPlant.transform.position + randomPositionFromMonsterPlant, ratio);
                ControllerGrabObjectScript.objectInHand.transform.rotation = Quaternion.Slerp(driftRotation, startRotation, ratio);
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

        ControllerGrabObject ControllerGrabObjectScript = gameObContainingScript.GetComponent<ControllerGrabObject>();
        driftPosition = ControllerGrabObjectScript.objectInHand.transform.position;
        driftRotation = ControllerGrabObjectScript.objectInHand.transform.rotation;

        Rigidbody rb = ControllerGrabObjectScript.objectInHand.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }


    private void StopDrift()
    {
        isDrifting = false;

        ControllerGrabObject ControllerGrabObjectScript = gameObContainingScript.GetComponent<ControllerGrabObject>();
        ControllerGrabObjectScript.objectInHand.transform.position = monsterPlant.transform.position + randomPositionFromMonsterPlant;
        ControllerGrabObjectScript.objectInHand.transform.rotation = startRotation;

        Rigidbody rb = ControllerGrabObjectScript.objectInHand.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
