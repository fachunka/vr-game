using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCollision : MonoBehaviour
{
    public GameObject gameObContainingScript;

    public GameObject gameObLightupChicken;
    public GameObject gameObLightupMirenda;
    public GameObject gameObLightupCornmeal;

    public bool ingredientsCollided;

    bool cornmealTouching;
    bool mirendaLeafTouching;
    bool chickenTouching;

    public int objectColliding;

    // Use this for initialization
    void Start()
    {
        ingredientsCollided = false;
        cornmealTouching = false;
        mirendaLeafTouching = false;
        chickenTouching = false;

        objectColliding = 0;
    }

    public void Reset()
    {
        ingredientsCollided = false;
        cornmealTouching = false;
        mirendaLeafTouching = false;
        chickenTouching = false;
        objectColliding = 0;
    }
    //-----------------------------------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(objectColliding);

        BlinkButton BlinkButtonScript = gameObContainingScript.GetComponent<BlinkButton>();

        blink_chicken ChickenButtonScript = gameObLightupChicken.GetComponent<blink_chicken>();
        blink_mirenda MirendaButtonScript = gameObLightupMirenda.GetComponent<blink_mirenda>();
        blink_cornmeal CornmealButtonScript = gameObLightupCornmeal.GetComponent<blink_cornmeal>();

        //Debug.Log("Number of object colliding stove2: " + objectColliding);

        //if all three ingredients for ugali dish is colliding with the stove, then send bool ingredientsCollided to "ReplaceUgali" script
        if (cornmealTouching == true & mirendaLeafTouching == true && chickenTouching == true)
        {
            ingredientsCollided = true;
           // print("colliding?");
        }

        else
        {
            ingredientsCollided = false;
        }

        if (chickenTouching == true)
        {
            ChickenButtonScript.turnOnBlinkButton = true;
        }


        else if (chickenTouching == false)
        {
            ChickenButtonScript.turnOnBlinkButton = false;
            //ChickenButtonScript.material.DisableKeyword("_EMISSION");
        }

        if (cornmealTouching == true)
        {
            CornmealButtonScript.turnOnBlinkButton = true;
        }


        else if (cornmealTouching == false)
        {
            CornmealButtonScript.turnOnBlinkButton = false;
        }

        if (mirendaLeafTouching == true)
        {
            MirendaButtonScript.turnOnBlinkButton = true;
        }


        else if (mirendaLeafTouching == false)
        {
            MirendaButtonScript.turnOnBlinkButton = false;
        }


        //-----------------------------------------
        //activate button blinking
        if (objectColliding == 3)
        {
            BlinkButtonScript.turnOnBlinkButton = true;
        }
        //if it's not 3, deactivate button
        else if (objectColliding != 3)
        {
            BlinkButtonScript.turnOnBlinkButton = false;
            BlinkButtonScript.material.DisableKeyword("_EMISSION");

        }
    }

    //-----------------------------------------------------------------------------------------------------------------
    private void OnTriggerStay(Collider collision)
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        //count objects colliding with the stove
        objectColliding++;

        if (collision.gameObject.tag == "Cornmeal")
        {
            print("cornmealTouching");
            cornmealTouching = true;
        }



        if (collision.gameObject.tag == "MirendaLeaf")
        {
            // print("mirendaLeafTouching");
            mirendaLeafTouching = true;
        }


        if (collision.gameObject.tag == "Chicken")
        {
            // print("chickenTouching");
            chickenTouching = true;
        }
     
    }

    private void OnTriggerExit(Collider collision)
    {
        objectColliding--;

            print("cornmealTouching");
        if (collision.gameObject.tag == "Cornmeal")
        {
            cornmealTouching = false;
        }



        if (collision.gameObject.tag == "MirendaLeaf")
        {
            mirendaLeafTouching = false;
        }


        if (collision.gameObject.tag == "Chicken")
        {
            chickenTouching = false;
        }
    }
}