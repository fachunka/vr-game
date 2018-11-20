using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//if three items are placed over the stove, initiatate ugali dish
public class ReplaceUgali : MonoBehaviour
{
    public GameObject gameObContainingScript;
    public GameObject Ugali;

    bool replaceObjects;

    // Use this for initialization
    void Start()
    {
        replaceObjects = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (replaceObjects == true)
        {
            //run this in 2seconds(after 2seconds)
            Invoke("Replace", 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StoveCollision StoveCollisionScript = gameObContainingScript.GetComponent<StoveCollision>();

        if (other.gameObject.tag == "controller")
        {
            print("button clicked");

            //if button has been pressed
            if (StoveCollisionScript.ingredientsCollided == true)
            {
                print("replacing with Uganda dish");
                replaceObjects = true;
                StoveCollisionScript.ingredientsCollided = false;
            }
        }
    }

    void Replace()
    {
        GameObject ugali = Instantiate(Ugali, transform.position, transform.rotation) as GameObject;

        Destroy(GameObject.FindWithTag("Cornmeal"));
        Destroy(GameObject.FindWithTag("Chicken"));
        Destroy(GameObject.FindWithTag("MirendaLeaf"));

        replaceObjects = false;
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    List<GameObject> allCollisions = new List<GameObject>();

    //    allCollisions.Add(collision.gameObject);

    //    Debug.Log(allCollisions.Count);

    //    //Debug.Log(collision.Length);
    //}
}


// if (Stove2.gameObject.tag == "Cornmeal" && Stove2.gameObject.tag == "Chicken" && Stove2.gameObject.tag == "MirendaLeaf")
//        {
//            print("all ingredients collected");

//            //if button has been pressed
//            if (other.gameObject.tag == "ButtonUgali")
//            {
//                print("replacing with Uganda dish");
//replaceObjects = true;
//    }

//}