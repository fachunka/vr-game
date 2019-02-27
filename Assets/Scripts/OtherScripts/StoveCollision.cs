using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCollision : MonoBehaviour
{
    public GameObject gameObContainingScript;

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
        if (collision.gameObject.tag == "Cornmeal")
        {
           // print("cornmealTouching");
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

    private void OnTriggerEnter(Collider collision)
    {
        //count objects colliding with the stove
        objectColliding++;
    }

    private void OnTriggerExit(Collider collision)
    {
        objectColliding--;
    }
}