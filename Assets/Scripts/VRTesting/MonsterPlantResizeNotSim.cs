using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPlantResizeNotSim : MonoBehaviour
{
    public GameObject gameObContainingScript;
    public GameObject gameObContainingScript2;
    public bool monsterFeeded = false;
    bool meatChunkDeleted = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if meatchunk collides, make it disappear
        if (monsterFeeded == true)
        {
            if (meatChunkDeleted == false)
            {
                Debug.Log("Monster feeded, deleting meat chunk");

                //find object that collided with monster, release it and delete the gameobject
                ControllerGrabObject ControllerGrabObjectScript = gameObContainingScript.GetComponent<ControllerGrabObject>();
                ControllerGrabObject ControllerGrabObjectScript2 = gameObContainingScript2.GetComponent<ControllerGrabObject>();

                if (ControllerGrabObjectScript.objectInHand != null)
                {
                    if (ControllerGrabObjectScript.objectInHand)
                    {
                        ControllerGrabObjectScript.ReleaseObjectControlledByOtherScript();
                        Destroy(ControllerGrabObjectScript.objectInHand);
                    }
                }

                if (ControllerGrabObjectScript2.objectInHand != null)
                {
                    if (ControllerGrabObjectScript2.objectInHand)
                    {
                        ControllerGrabObjectScript2.ReleaseObjectControlledByOtherScript();
                        Destroy(ControllerGrabObjectScript2.objectInHand);
                    }
                }

                meatChunkDeleted = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //if object collides with meat chunk, make it small
        if (monsterFeeded == false)
        {
            if (other.gameObject.tag == "MeatChunk")
            {
                Debug.Log("Monster feeded");
                transform.localScale = new Vector3(12.5f, 12.5f, 12.5f);
                transform.Translate(0, 0.4f, 0);
                monsterFeeded = true;
            }
        }
    }
}
