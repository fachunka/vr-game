using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupJ : MonoBehaviour {

    //GameObjects
    private GameObject rightHand;
    public GameObject meatChunk;
    public GameObject scissors;

    //accessing script from ScissorStatusChange
   public GameObject inAnimateScissorsGameObject;



    //    private GameObject camera;

    //Current Object Name
    private string currentObj;

    //Player Location
    private Vector3 loc;
    //    private Vector3 posx;

    //Bools
    private bool inHand;
    private bool triggerEnteredMeatChunk;
    private bool triggerEnteredScissors;

    //Sound
    //public AudioClip soundClip;
    //public AudioSource soundSource;


    // Use this for initialization
    void Start()
    {
        //Object
        rightHand = this.gameObject;
        currentObj = "null";

        //Bools
        inHand = false;
        triggerEnteredMeatChunk = false;
        triggerEnteredScissors = false;

        //Sound
        //soundSource.clip = soundClip;
    }

    // Update is called once per frame
    void Update()
    {
        //get ScissorStatusChange component - script 
        //from public gameobject which contains this script
        ScissorStatusChange ScissorStatusChangeScript = inAnimateScissorsGameObject.GetComponent<ScissorStatusChange>();

        //-------------------------------------------------------------------------------------------
        loc = rightHand.transform.localPosition;
        //Debug.Log(rightHand.gameObject.transform.childCount);
        if (rightHand.gameObject.transform.childCount == 2)
        {
            currentObj = rightHand.gameObject.transform.GetChild(1).gameObject.name;
            //Debug.Log(currentObj);
        }

        //-------------------------------------------------------------------------------------------
        //key pickup
        if (triggerEnteredMeatChunk == true)
        {
            if (Input.GetKeyDown("m") && rightHand.gameObject.transform.childCount == 1)
            {
                print("m key was pressed");


                meatChunk.transform.parent = rightHand.transform;
                meatChunk.transform.localPosition = Vector3.zero;
                //                Reset(key);
                meatChunk.transform.rotation = Quaternion.Euler(0, 90, 0);
                meatChunk.GetComponent<Rigidbody>().velocity = Vector3.zero;
                meatChunk.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;


                meatChunk.GetComponent<Rigidbody>().useGravity = false;
                meatChunk.GetComponent<BoxCollider>().isTrigger = true;

                inHand = true;
                //Debug.Log(inHand);


                //Debug.Log(rightHand.gameObject.transform.GetChild(1).gameObject);
            }

        }

        // drop key item
        if (currentObj == "Meat Chunk" && Input.GetKeyDown("m") && rightHand.gameObject.transform.childCount == 2)
        {
            print("m key was pressed");
            meatChunk.transform.parent = null;
            meatChunk.transform.localPosition = new Vector3(loc.x, 2.0f, loc.z);
            //                Reset(key);
            meatChunk.transform.rotation = Quaternion.Euler(0, 90, 0);
            meatChunk.GetComponent<Rigidbody>().velocity = Vector3.zero;
            meatChunk.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            meatChunk.GetComponent<Rigidbody>().useGravity = true;
            meatChunk.GetComponent<BoxCollider>().isTrigger = false;

            inHand = false;
            //Debug.Log(inHand);
            currentObj = "null";

        }

        //-------------------------------------------------------------------------------------------
        //scissors pickup
        if (triggerEnteredScissors == true)
        {
            if (Input.GetKeyDown("m") && rightHand.gameObject.transform.childCount == 1)
            {
                print("m key was pressed");

                scissors.transform.parent = rightHand.transform;
                scissors.transform.localPosition = Vector3.zero;
                //                Reset(key);
                scissors.transform.rotation = Quaternion.Euler(0, 0, 0);
                scissors.GetComponent<Rigidbody>().velocity = Vector3.zero;
                scissors.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;


                scissors.GetComponent<Rigidbody>().useGravity = false;
                scissors.GetComponent<BoxCollider>().isTrigger = true;

                inHand = true;
                //Debug.Log(inHand);


                //Debug.Log(rightHand.gameObject.transform.GetChild(1).gameObject);
            }
        }

        // drop scissors item
        //if ((currentObj == "ScissorsInanimate" && Input.GetKeyDown("m") && rightHand.gameObject.transform.childCount == 2))
        //{
        //    print("m key was pressed");
        //    scissors.transform.parent = null;
        //    scissors.transform.localPosition = new Vector3(loc.x, 2.0f, loc.z);
        //    //                Reset(key);
        //    scissors.transform.rotation = Quaternion.Euler(0, 0, 0);
        //    scissors.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //    scissors.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        //    scissors.GetComponent<Rigidbody>().useGravity = true;
        //    scissors.GetComponent<BoxCollider>().isTrigger = false;

        //    inHand = false;
        //    //Debug.Log(inHand);
        //    currentObj = "null";
        //}

        // drop and make dissappear scissors item when inanimate scissors collide with box
        if ((currentObj == "ScissorsInanimate" && ScissorStatusChangeScript.letGoInAnimateScissors == true))
        {
            print("let go scissors");
            scissors.transform.parent = null;
            scissors.transform.localPosition = new Vector3(loc.x, 2.0f, loc.z);
            scissors.transform.localScale = new Vector3(0, 0, 0);
            //                Reset(key);
            scissors.transform.rotation = Quaternion.Euler(0, 0, 0);
            scissors.GetComponent<Rigidbody>().velocity = Vector3.zero;
            scissors.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            scissors.GetComponent<Rigidbody>().useGravity = true;
            scissors.GetComponent<BoxCollider>().isTrigger = false;

            inHand = false;
            //Debug.Log(inHand);
            currentObj = "null";

            ScissorStatusChangeScript.letGoInAnimateScissors = false;
        }

    }


    void OnTriggerEnter(Collider col)
    {

        // We set this variable to indicate that character is in trigger
        // meat chunk trigger
        if (col.gameObject.name == "Meat Chunk Trigger")
        {
            Debug.Log("touching Meat Chunk");
            triggerEnteredMeatChunk = true;
        }

        // scissors trigger
        if (col.gameObject.name == "ScissorsInanimate Trigger")
        {
            Debug.Log("touching scissors");
            triggerEnteredScissors = true;
        }
    }


    void OnTriggerExit(Collider col)
    {
        // We reset this variable since character is no longer in the trigger
        // meat chunk trigger
       if (col.gameObject.name == "Meat Chunk Trigger")
        {
            Debug.Log("not touching Meat Chunk");
            triggerEnteredMeatChunk = false;

        }

        // scissors trigger
        if (col.gameObject.name == "ScissorsInanimate Trigger")
        {
            Debug.Log("not touching scissors");
            triggerEnteredScissors = false;

        }

    }

    //reset dynamic
    //    void Reset (GameObject name) {
    //
    //        print("m key was pressed");
    //        name.transform.parent = null;
    //        name.transform.localPosition = new Vector3(loc.x, 2.0f, loc.z);
    //        name.transform.rotation = Quaternion.Euler(0, 90, 0);
    //        name.GetComponent<Rigidbody>().velocity = Vector3.zero;
    //        name.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    //        name.GetComponent<Rigidbody>().useGravity = true;
    //        name.GetComponent<CapsuleCollider>().isTrigger = false;
    //
    //        Debug.Log(name);
    //        Debug.Log(loc);
    //
    //
    //    }
}

