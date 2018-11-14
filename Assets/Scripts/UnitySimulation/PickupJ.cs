using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupJ : MonoBehaviour
{
    //GameObjects
    private GameObject rightHand;
    private GameObject myMeat;
    public GameObject key;
    public GameObject meatChunk;
    public GameObject meat;
    public GameObject scissors;
    public GameObject remainsCube1/*, remainsCube2, remainsCube3*/;
    public GameObject storyObject1;

    //accessing script from ScissorStatusChange
    public GameObject gameObContainingScript;

    //private GameObject camera;

    //Current Object Name
    private string currentObj;

    //Player Location
    private Vector3 loc;
    //private Vector3 posx;

    //Bools
    private bool inHand;
    private bool triggerEnteredKey;
    private bool triggerEnteredMeatChunk;
    private bool triggerEnteredMeat;
    private bool triggerEnteredScissors;
    private bool triggerEnteredRemainsCube1/*, triggerEnteredRemainsCube2, triggerEnteredRemainsCube3*/;
    private bool triggerEnteredstoryObject1;

    public bool releasedObject = false;

    //Sound
    //public AudioClip soundClip;
    //public AudioSource soundSource;

    private void Awake()
    {
        myMeat = Instantiate(meat, Vector3.zero, Quaternion.identity);
    }

    // Use this for initialization
    void Start()
    {
        //Object
        rightHand = this.gameObject;
        currentObj = "null";

        //Bools
        inHand = false;
        triggerEnteredMeatChunk = false;
        triggerEnteredMeat = false;
        triggerEnteredScissors = false;
        triggerEnteredRemainsCube1 = false;
        triggerEnteredstoryObject1 = false;
        //triggerEnteredRemainsCube2 = false;
        //triggerEnteredRemainsCube3 = false;

        //Sound
        //soundSource.clip = soundClip;
    }

    // Update is called once per frame
    void Update()
    {
        //get ScissorStatusChange component - script 
        //from public gameobject which contains this script
        ScissorStatusChange ScissorStatusChangeScript = gameObContainingScript.GetComponent<ScissorStatusChange>();

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
        if (triggerEnteredKey == true)
        {
            if (Input.GetKeyDown("m") && rightHand.gameObject.transform.childCount == 1)
            {
                print("m key was pressed");

                key.transform.parent = rightHand.transform;
                key.transform.localPosition = Vector3.zero;
                //                Reset(key);
                key.transform.rotation = Quaternion.Euler(0, 90, 0);
                key.GetComponent<Rigidbody>().velocity = Vector3.zero;
                key.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;


                key.GetComponent<Rigidbody>().useGravity = false;
                key.GetComponent<BoxCollider>().isTrigger = true;

                inHand = true;
                Debug.Log(inHand);

                Debug.Log(rightHand.gameObject.transform.GetChild(1).gameObject);
            }
        }

        // drop item
        if (currentObj == "Key" && Input.GetKeyDown("m") && rightHand.gameObject.transform.childCount == 2)
        {
            print("m key was pressed");
            key.transform.parent = null;
            key.transform.localPosition = new Vector3(loc.x, 2.0f, loc.z);
            //                Reset(key);
            key.transform.rotation = Quaternion.Euler(0, 90, 0);
            key.GetComponent<Rigidbody>().velocity = Vector3.zero;
            key.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            key.GetComponent<Rigidbody>().useGravity = true;
            key.GetComponent<BoxCollider>().isTrigger = false;

            inHand = false;
            Debug.Log(inHand);
            currentObj = "null";
        }

        //-------------------------------------------------------------------------------------------
        //meatchunk pickup
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

        //drop meatchunk item
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

        //drop scissors item
        if ((currentObj == "ScissorsInanimate" && Input.GetKeyDown("m") && rightHand.gameObject.transform.childCount == 2))
        {
            print("m key was pressed");
            scissors.transform.parent = null;
            scissors.transform.localPosition = new Vector3(loc.x, 2.0f, loc.z);
            //                Reset(key);
            scissors.transform.rotation = Quaternion.Euler(0, 0, 0);
            scissors.GetComponent<Rigidbody>().velocity = Vector3.zero;
            scissors.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            scissors.GetComponent<Rigidbody>().useGravity = true;
            scissors.GetComponent<BoxCollider>().isTrigger = false;

            inHand = false;
            //Debug.Log(inHand);
            currentObj = "null";
        }

        //drop and make dissappear scissors item when inanimate scissors collide with box
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

        //-------------------------------------------------------------------------------------------
        //meat pickup
        if (triggerEnteredMeat == true)
        {
            if (Input.GetKeyDown("m") && rightHand.gameObject.transform.childCount == 1)
            {
                print("m key was pressed");

                myMeat.transform.parent = rightHand.transform;
                myMeat.transform.localPosition = Vector3.zero;
                //                Reset(key);
                myMeat.transform.rotation = Quaternion.Euler(0, 90, 0);
                myMeat.GetComponent<Rigidbody>().velocity = Vector3.zero;
                myMeat.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;


                myMeat.GetComponent<Rigidbody>().useGravity = false;
                myMeat.GetComponent<BoxCollider>().isTrigger = true;

                inHand = true;

                //Debug.Log(inHand);

                //Debug.Log(rightHand.gameObject.transform.GetChild(1).gameObject);
            }
        }

        //drop meat item
        if (currentObj == "Meat(Clone)" && Input.GetKeyDown("m") && rightHand.gameObject.transform.childCount == 2)
        {
            print("m key was pressed");

            myMeat.transform.parent = null;
            myMeat.transform.localPosition = new Vector3(loc.x, 2.0f, loc.z);
            //                Reset(key);
            myMeat.transform.rotation = Quaternion.Euler(0, 90, 0);
            myMeat.GetComponent<Rigidbody>().velocity = Vector3.zero;
            myMeat.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            myMeat.GetComponent<Rigidbody>().useGravity = true;
            myMeat.GetComponent<BoxCollider>().isTrigger = false;

            inHand = false;
            //Debug.Log(inHand);
            currentObj = "null";
        }
        //-------------------------------------------------------------------------------------------
        //remainsCube pickup
        if (triggerEnteredRemainsCube1 == true)
        {
            if (Input.GetKeyDown("m") && rightHand.gameObject.transform.childCount == 1)
            {
                print("m key was pressed");

                remainsCube1.transform.parent = rightHand.transform;
                remainsCube1.transform.localPosition = Vector3.zero;
                //                Reset(key);
                remainsCube1.transform.rotation = Quaternion.Euler(0, 90, 0);
                remainsCube1.GetComponent<Rigidbody>().velocity = Vector3.zero;
                remainsCube1.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;


                remainsCube1.GetComponent<Rigidbody>().useGravity = false;
                remainsCube1.GetComponent<BoxCollider>().isTrigger = true;

                inHand = true;
                //Debug.Log(inHand);

                //Debug.Log(rightHand.gameObject.transform.GetChild(1).gameObject);
            }
        }

        //drop remainsCube item
        if (currentObj == "Cube (1)" && Input.GetKeyDown("m") && rightHand.gameObject.transform.childCount == 2)
        {
            print("m key was pressed");

            remainsCube1.transform.parent = null;
            remainsCube1.transform.localPosition = new Vector3(loc.x, 2.0f, loc.z);
            //                Reset(key);
            remainsCube1.transform.rotation = Quaternion.Euler(0, 90, 0);
            remainsCube1.GetComponent<Rigidbody>().velocity = Vector3.zero;
            remainsCube1.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            remainsCube1.GetComponent<Rigidbody>().useGravity = true;
            remainsCube1.GetComponent<BoxCollider>().isTrigger = false;

            inHand = false;
            //Debug.Log(inHand);
            currentObj = "null";
        }

        //-------------------------------------------------------------------------------------------
        //storyObject1 pickup
        if (triggerEnteredstoryObject1 == true)
        {
            if (Input.GetKeyDown("m") && rightHand.gameObject.transform.childCount == 1)
            {
                print("m key was pressed");

                storyObject1.transform.parent = rightHand.transform;
                storyObject1.transform.localPosition = Vector3.zero;
                //                Reset(key);
                storyObject1.transform.rotation = Quaternion.Euler(0, 90, 0);
                storyObject1.GetComponent<Rigidbody>().velocity = Vector3.zero;
                storyObject1.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;


                storyObject1.GetComponent<Rigidbody>().useGravity = false;
                storyObject1.GetComponent<BoxCollider>().isTrigger = true;

                inHand = true;
                //Debug.Log(inHand);

                //Debug.Log(rightHand.gameObject.transform.GetChild(1).gameObject);

                releasedObject = false;
            }
        }

        //drop storyObject1 item
        if (currentObj == "StoryObject1" && Input.GetKeyDown("m") && rightHand.gameObject.transform.childCount == 2)
        {
            print("m key was pressed");

            storyObject1.transform.parent = null;
            storyObject1.transform.localPosition = new Vector3(loc.x + 0.6f, 2.0f, loc.z);
            //                Reset(key);
            storyObject1.transform.rotation = Quaternion.Euler(0, 90, 0);
            storyObject1.GetComponent<Rigidbody>().velocity = Vector3.zero;
            storyObject1.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            storyObject1.GetComponent<Rigidbody>().useGravity = true;
            storyObject1.GetComponent<BoxCollider>().isTrigger = false;

            inHand = false;
            //Debug.Log(inHand);
            currentObj = "null";

            releasedObject = true;
        }
    }


    void OnTriggerEnter(Collider col)
    {
        //Chest trigger
        //if (col.gameObject.name == "Chest")
        //{
        //    Debug.Log("Benylin?");
        //    if (rightHand.gameObject.transform.GetChild(1).gameObject.name == "Key")
        //    {
        //        soundSource.Play();
        //        Debug.Log("No Benylin");
        //    }
        //    else if (rightHand.gameObject.transform.GetChild(1).gameObject.name == "Lime")
        //    {
        //        soundSource.Play();
        //        Debug.Log("Yes Benylin");
        //        lidopen.GetComponent<Animator>().SetBool("open", true);
        //   
        //}

        // We set this variable to indicate that character is in trigger

        //Key trigger
        if (col.gameObject.name == "Key Trigger")
        {
            Debug.Log("touching key");
            triggerEnteredKey = true;
        }

        // meat chunk trigger
        if (col.gameObject.name == "Meat Chunk Trigger")
        {
            Debug.Log("touching Meat Chunk");
            triggerEnteredMeatChunk = true;
        }

        // meat trigger
        if (col.gameObject.name == "Meat Trigger")
        {
            Debug.Log("touching Meat");
            triggerEnteredMeat = true;
        }

        // scissors trigger
        if (col.gameObject.name == "ScissorsInanimate Trigger")
        {
            Debug.Log("touching scissors");
            triggerEnteredScissors = true;
        }

        // remainsCube1 trigger
        if (col.gameObject.name == "Cube (1) Trigger")
        {
            Debug.Log("touching remainsCube 1");
            triggerEnteredRemainsCube1 = true;
        }

        // storyObject1 trigger
        if (col.gameObject.name == "StoryObject1 Trigger")
        {
            Debug.Log("touching stroyObject 1");
            triggerEnteredstoryObject1 = true;
        }
    }


    void OnTriggerExit(Collider col)
    {
        // We reset this variable since character is no longer in the trigger

        //Key trigger
        if (col.gameObject.name == "Key Trigger")
        {
            Debug.Log("not touching key");
            triggerEnteredKey = false;
        }

        // meat chunk trigger
        if (col.gameObject.name == "Meat Chunk Trigger")
        {
            Debug.Log("not touching Meat Chunk");
            triggerEnteredMeatChunk = false;
        }

        // meat trigger
        if (col.gameObject.name == "Meat Trigger")
        {
            Debug.Log("not touching Meat");
            triggerEnteredMeat = false;
        }

        // scissors trigger
        if (col.gameObject.name == "ScissorsInanimate Trigger")
        {
            Debug.Log("not touching scissors");
            triggerEnteredScissors = false;
        }

        // remainsCube1 trigger
        if (col.gameObject.name == "Cube (1) Trigger")
        {
            Debug.Log("not touching remainsCube 1");
            triggerEnteredRemainsCube1 = false;
        }

        // storyObject1 trigger
        if (col.gameObject.name == "StoryObject1 Trigger")
        {
            Debug.Log("not touching stroyObject 1");
            triggerEnteredstoryObject1 = false;
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

