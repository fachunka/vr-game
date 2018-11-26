using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPlantResizeNotSim : MonoBehaviour
{
    public GameObject gameObContainingScript;
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
                if (ControllerGrabObjectScript.objectInHand != null)
                {
                    if (ControllerGrabObjectScript.objectInHand)
                    {
                        ControllerGrabObjectScript.ReleaseObjectControlledByOtherScript();
                        Destroy(ControllerGrabObjectScript.objectInHand);
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
                transform.localScale = new Vector3(0.15f, 0.3f, 0.15f);
                transform.position = new Vector3(-1.83f, 1.06f, 1.198f);
                monsterFeeded = true;
            }
        }
    }
}
