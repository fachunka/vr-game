using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//destroy when 3objects don't match the ingredients needed and button pressed

public class DestroyIngredient : MonoBehaviour
{
    public GameObject gameObContainingScript;
    public GameObject gameObContainingScript2;

    bool threeIngredientscollected;
    bool buttonPressed;

    List<GameObject> currentCollisions = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        threeIngredientscollected = false;
        buttonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        StoveCollision StoveCollisionScript = gameObContainingScript.GetComponent<StoveCollision>();
        ReplaceUgali ReplaceUgaliScript = gameObContainingScript2.GetComponent<ReplaceUgali>();

        // Add the GameObject collided with to the list.
        currentCollisions.Add(col.gameObject);

        //if stove2 colliding with 3 objects
        if (StoveCollisionScript.objectColliding == 3)
        {
            //if they are not 3 ingredients needed
            if (StoveCollisionScript.ingredientsCollided == false)
            {
                //if button is pressed
                if (ReplaceUgaliScript.buttonPressed == true)
                {
                    //destory game objects colliding with stove2
                    foreach (GameObject gObject in currentCollisions)
                    {
                        Destroy(col.gameObject);
                    }
                }
            }
        }
    }

}
