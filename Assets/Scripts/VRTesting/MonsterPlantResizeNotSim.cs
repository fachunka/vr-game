﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPlantResizeNotSim : MonoBehaviour
{
    public GameObject gameObContainingScript;
    public GameObject gameObContainingScript2;
    public bool monsterFeeded = false;
    bool meatChunkDeleted = false;

    private int savedMonsterFeeded = 0;
    private int savedMeatChunkDeleted = 0;

    private bool makeItSmallOnce = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(PlayerPrefs.GetInt("savedMonsterFeeded").ToString());
        //Debug.Log(PlayerPrefs.GetInt("savedMeatChunkDeleted").ToString());


        savedMonsterFeeded = PlayerPrefs.GetInt("savedMonsterFeeded");
        savedMeatChunkDeleted = PlayerPrefs.GetInt("savedMeatChunkDeleted");

        //if meatchunk collides, make it disappear
        if (savedMonsterFeeded == 1)
        {
            if (savedMeatChunkDeleted == 0)
            {
               //Debug.Log("Monster feeded, deleting meat chunk");

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
                PlayerPrefs.SetInt("savedMeatChunkDeleted", 1);



            }
            if (makeItSmallOnce == false)
            {
                transform.localScale = new Vector3(12.5f, 12.5f, 12.5f);
                transform.Translate(0, 0.4f, 0);
                makeItSmallOnce = true;
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {

        savedMonsterFeeded = PlayerPrefs.GetInt("savedMonsterFeeded");
        savedMeatChunkDeleted = PlayerPrefs.GetInt("savedMeatChunkDeleted");

        //if object collides with meat chunk, make it small
        if (savedMonsterFeeded == 0)
        {
            if (other.gameObject.tag == "MeatChunk")
            {
                //Debug.Log("Monster feeded");
                
                monsterFeeded = true;
                PlayerPrefs.SetInt("savedMonsterFeeded", 1);

                gameObject.SendMessage("playEating");
            }
        }
    }
}
