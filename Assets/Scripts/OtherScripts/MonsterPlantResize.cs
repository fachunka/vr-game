using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPlantResize : MonoBehaviour
{
    public bool monsterFeeded = false;
    bool meatChunkDeleted = false;
    GameObject inHand;
    Component[] grabObjects;

    // Use this for initialization
    void Start()
    {
        inHand = GameObject.Find("[CameraRig]");
    }

    // Update is called once per frame
    void Update()
    {

        grabObjects = inHand.GetComponentsInChildren<ControllerGrabObject>();

        foreach (ControllerGrabObject grabObj in grabObjects)
        {
            Debug.Log(grabObj.objectInHandName);
        }

        //if meatchunk collides, make it disappear
        if (monsterFeeded == true)
        {
            if (meatChunkDeleted == false)
            {
                Debug.Log("Monster feeded, deleting meat chunk");
                //find object that collided with monster and delete the gameobject
                //Destroy(gameObject);
                GameObject.Find("Cube (1)").transform.localScale = new Vector3(0, 0, 0);
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
                monsterFeeded = true;

                gameObject.SendMessage("playEating");     // call playEating function (play eating and then sleeping sound) in the monsterPlantAudio.cs

            }
        }
    }
}