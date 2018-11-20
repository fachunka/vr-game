using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCollision : MonoBehaviour
{
    public bool ingredientsCollided;

    bool cornmealTouching;
    bool mirendaLeafTouching;
    bool chickenTouching;

    // Use this for initialization
    void Start()
    {
        ingredientsCollided = false;
        cornmealTouching = false;
        mirendaLeafTouching = false;
        chickenTouching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cornmealTouching == true & mirendaLeafTouching == true && chickenTouching == true)
        {
            ingredientsCollided = true;
        }

        else
        {
            ingredientsCollided = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Cornmeal")
        {
            //print("cornmealTouching");
            cornmealTouching = true;
        }
    
        if (collision.gameObject.tag == "MirendaLeaf")
        {
            //print("mirendaLeafTouching");
            mirendaLeafTouching = true;
        }

        if (collision.gameObject.tag == "Chicken")
        {
            //print("chickenTouching");
            chickenTouching = true;
        }
    }

}