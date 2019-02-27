using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//destroy when 3objects don't match the ingredients needed and button pressed

public class DestroyIngredient : MonoBehaviour
{
    public GameObject gameObContainingScript;
    public GameObject gameObContainingScript2;

    //bool threeIngredientscollected;
    bool buttonPressed;

    List<GameObject> currentCollisions = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        //threeIngredientscollected = false;
        buttonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        StoveCollision StoveCollisionScript = gameObContainingScript.GetComponent<StoveCollision>();
        ReplaceUgali ReplaceUgaliScript = gameObContainingScript2.GetComponent<ReplaceUgali>();

        //Debug.Log(currentCollisions);

        // Add the GameObject collided with to the list.

        //if stove2 colliding with 3 objects
        if (StoveCollisionScript.objectColliding == 3)
        {
            //if they are not 3 ingredients needed
            if (StoveCollisionScript.ingredientsCollided == false)
            {
                //if button is pressed
                if (ReplaceUgaliScript.buttonPressed == true)
                {
                    print("Hello");

                    //destroy game objects colliding with stove2
                    foreach (GameObject gObject in currentCollisions)
                    {
                        print(gObject.gameObject);
                        //Destroy(gObject.gameObject);
                        StoveCollisionScript.Reset();
                    }
                }
            }
        }


    }

    void OnTriggerEnter(Collider col)
    {
     //   print(col.gameObject);
        currentCollisions.Add(col.gameObject);
        
    }

}
