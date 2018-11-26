﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//if three items are placed over the stove, initiatate ugali dish
public class ReplaceUgali : MonoBehaviour
{
    public GameObject gameObContainingScript;
    public GameObject Ugali;
    public GameObject StoveUgaliDish;

    Vector3 UgaliPosition;

    bool replaceObjects;
    bool handNotTouchedButtonBefore;

    public bool buttonPressed;

    // Use this for initialization
    void Start()
    {
        replaceObjects = false;
        handNotTouchedButtonBefore = true;
        UgaliPosition = new Vector3(0, 0.6f, 0);

        buttonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (replaceObjects == true)
        {
            //run this in 2seconds(after 2seconds)
            Invoke("Replace", 2);
            replaceObjects = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StoveCollision StoveCollisionScript = gameObContainingScript.GetComponent<StoveCollision>();

        //if gamecontroller collider with button
        if (other.gameObject.tag == "GameController")
        {
            buttonPressed = true;

            print("button clicked");

            //if all the ingredients are colliding with stove
            if (StoveCollisionScript.ingredientsCollided == true)
            {
                //if hands were not touching the button before(to prevent clicking button several times once)
                if (handNotTouchedButtonBefore == true)
                {
                    print("replacing with Uganda dish");
                    replaceObjects = true;
                    StoveCollisionScript.ingredientsCollided = false;

                    handNotTouchedButtonBefore = false;
                }
            }

            //------------------------------------------------------------------
            //if button clicked but 3 ingredients don't match, delete them all
            if (handNotTouchedButtonBefore == true)
            {
                handNotTouchedButtonBefore = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        buttonPressed = false;

        handNotTouchedButtonBefore = true;
    }

    void Replace()
    {
        GameObject ugali = Instantiate(Ugali, StoveUgaliDish.transform.position + UgaliPosition, StoveUgaliDish.transform.rotation) as GameObject;

        Destroy(GameObject.FindWithTag("Cornmeal"));
        Destroy(GameObject.FindWithTag("Chicken"));
        Destroy(GameObject.FindWithTag("MirendaLeaf"));
    }
}