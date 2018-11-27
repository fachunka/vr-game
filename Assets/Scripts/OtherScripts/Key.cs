using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //public GameObject chestHalf;
    public GameObject gameObContainingScript;
    //GameObject inHand;
    //Component[] grabObjects;
    //GameObject objectInHand;

    private bool keyInBox;

    // Use this for initialization
    void Start()
    {
        keyInBox = false;
        //inHand = GameObject.Find("[CameraRig]");

    }

    // Update is called once per frame
    void Update()
    {
        //ControllerGrabObject ControllerGrabObjectScript = gameObContainingScript.GetComponent<ControllerGrabObject>();

        //grabObjects = inHand.GetComponentsInChildren<ControllerGrabObject>();

        //foreach (ControllerGrabObject grabObj in grabObjects)
        //{
        //    Debug.Log(grabObj.objectInHandName);
        //    objectInHand = grabObj.objectInHand;
        //}

        //if (objectInHand.tag == "Scissors")
        //{
        //    Destroy(objectInHand);
        //}


        if (keyInBox == true)
        {
            print("Key destroyed?");

            //if (ControllerGrabObjectScript.objectInHand != null)
            //{
               // ControllerGrabObjectScript.ReleaseObjectControlledByOtherScript();
           // }
            //Destroy(this.gameObject);
            //Destroy(GameObject.FindWithTag("Key"));

        }


    }

    void OnTriggerEnter(Collider other)
    {
  
        if (other.gameObject.name == "boxClosedPrefab")
        {
            keyInBox = true;
            print("collided key");
            print(keyInBox);

            print("Key destroyed?!?!?!");


            //Destroy(this.gameObject);
            //Destroy(GameObject.FindWithTag("Key"));
        }

    }
}
