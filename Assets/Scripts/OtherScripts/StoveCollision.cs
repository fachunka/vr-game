using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCollision : MonoBehaviour
{
    public bool ingredientsCollided;

    // Use this for initialization
    void Start()
    {
        ingredientsCollided = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Cornmeal" && collision.gameObject.tag == "Chicken" && collision.gameObject.tag == "MirendaLeaf")
        {
            ingredientsCollided = true;
        }
    }
}
