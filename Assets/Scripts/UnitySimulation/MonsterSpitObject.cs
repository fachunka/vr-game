using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * if wrong objects are given to the monster, it spits it out
 * if random object (lime/ scissors/ raw meat/ drink..etc) collides with monster, objects are thrown back to the ground below the thrown hand
 */
//script for testing in unity (simulator)

public class MonsterSpitObject : MonoBehaviour
{
    public GameObject gameObContainingScript;
    public GameObject monsterPlant;
    public GameObject key;

    Vector3 startPosition, driftPosition;
    Vector3 randomPositionFromMonsterPlant;

    Quaternion startRotation, driftRotation;

    public float driftSeconds = 0.3f;
    private float drifterTimer = 0;
    private bool isDrifting = false;
    bool releaseObjectInHand;

    // Use this for initialization
    void Start()
    {
        startPosition = key.transform.position;
        startRotation = key.transform.rotation;
        randomPositionFromMonsterPlant = new Vector3(0.8f, 0.5f, Random.Range(-0.2f, 0.2f));

        releaseObjectInHand = false;
    }

    // Update is called once per frame
    void Update()
    {
        PickupJ PickupJScript = gameObContainingScript.GetComponent<PickupJ>();

        //release the object in hand
        if (releaseObjectInHand == true)
        {
            PickupJScript.DropObjectKey();
            releaseObjectInHand = false;
        }

        //return the position
        if (PickupJScript.releasedObjectForReturnKey == true)
        {
            StartDrift();
            PickupJScript.releasedObjectForReturnKey = false;
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
                key.transform.position = Vector3.Lerp(driftPosition, monsterPlant.transform.position + randomPositionFromMonsterPlant, ratio);
                key.transform.rotation = Quaternion.Slerp(driftRotation, startRotation, ratio);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            Debug.Log("Something wrong feeded");
            releaseObjectInHand = true;
        }

    }

    private void StartDrift()
    {
        isDrifting = true;
        drifterTimer = 0;

        //driftPosition = new Vector3(0, 0, 0);
        driftPosition = key.transform.position;
        driftRotation = key.transform.rotation;

        Rigidbody rb = key.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }


    private void StopDrift()
    {
        isDrifting = false;
        key.transform.position = monsterPlant.transform.position + randomPositionFromMonsterPlant;
        key.transform.rotation = startRotation;

        Rigidbody rb = key.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}