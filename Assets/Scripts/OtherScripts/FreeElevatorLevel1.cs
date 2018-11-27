using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//if ugali dish and bottle are placed on the table, show particle effect and elevator activates + remove outlines from the storyobject
public class FreeElevatorLevel1 : MonoBehaviour
{
    bool ugaliTouching;
    bool bottleTouching;

    public bool freeAll;

    // Use this for initialization
    void Start()
    {
        ugaliTouching = false;
        bottleTouching = false;

        freeAll = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ugaliTouching == true && bottleTouching == true)
        {
            //print("particle effect activated");

            //send bool to particlelauncher
            freeAll = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ugali")
        {
            //print("cornmealTouching");
            ugaliTouching = true;

        }
        if (collision.gameObject.tag == "Bottle")
        {
            bottleTouching = true;
        }

    }
}
