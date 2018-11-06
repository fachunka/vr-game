using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickup : MonoBehaviour {
    
    //GameObjects
    private GameObject rightHand;
    public GameObject key;
    public GameObject lime;
    public GameObject lidopen;
//    private GameObject camera;

    //Current Object Name
    private string currentObj;


    
    //Player Location
    private Vector3 loc;
//    private Vector3 posx;

    
    //Bools
    private bool inHand;
    private bool triggerEnteredKey;
    private bool triggerEnteredLime;

    //Sound
    public AudioClip soundClip;
    public AudioSource soundSource;


	// Use this for initialization
	void Start () {
        
        //Object
        rightHand = this.gameObject;
        currentObj = "null";
        
        //Bools
        inHand = false;
        triggerEnteredKey = false;
        triggerEnteredLime = false;
        
        //Sound
        soundSource.clip = soundClip;
	}
	
	// Update is called once per frame
	void Update () {
        loc = rightHand.transform.localPosition;
        Debug.Log(rightHand.gameObject.transform.childCount);
        if (rightHand.gameObject.transform.childCount == 2){
        currentObj = rightHand.gameObject.transform.GetChild(1).gameObject.name;
        Debug.Log(currentObj);
        }
        
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
        

            //lime pickup
            if (triggerEnteredLime == true)
            {
                if (Input.GetKeyDown("m") && rightHand.gameObject.transform.childCount == 1)
                {
                    print("m key was pressed");
                    
                    
                    lime.transform.parent = rightHand.transform;
                    lime.transform.localPosition = Vector3.zero;
//                    Reset(lime);
                    lime.transform.rotation = Quaternion.Euler(0, 90, 0);
                    lime.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    lime.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    
                    lime.GetComponent<Rigidbody>().useGravity = false;
                    lime.GetComponent<CapsuleCollider>().isTrigger = true;
                    
                    inHand = true;
                    Debug.Log(inHand);
                    
                    
                    Debug.Log(rightHand.gameObject.transform.GetChild(1).gameObject);
                }
                
                
            }
            
            // drop item
            if (currentObj == "Lime" && Input.GetKeyDown("m") && rightHand.gameObject.transform.childCount == 2)
            {
                print("m key was pressed");
                lime.transform.parent = null;
                lime.transform.localPosition = new Vector3(loc.x, 2.0f, loc.z);
                //                Reset(lime);
                lime.transform.rotation = Quaternion.Euler(0, 90, 0);
                lime.GetComponent<Rigidbody>().velocity = Vector3.zero;
                lime.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                
                lime.GetComponent<Rigidbody>().useGravity = true;
                lime.GetComponent<CapsuleCollider>().isTrigger = false;
                
                inHand = false;
                Debug.Log(inHand);
                currentObj = "null";
            }


	}
    
    void OnTriggerEnter (Collider col)
    {
        
        // We set this variable to indicate that character is in trigger
        
        Debug.Log("trigger entered");
        
        
        //Chest trigger
        if(col.gameObject.name == "Chest")
        {
            Debug.Log("Benylin?");
            if (rightHand.gameObject.transform.GetChild(1).gameObject.name == "Key"){
                soundSource.Play();
                Debug.Log("No Benylin");
            }
            else if (rightHand.gameObject.transform.GetChild(1).gameObject.name == "Lime"){
                soundSource.Play();
                Debug.Log("Yes Benylin");
                lidopen.GetComponent<Animator>().SetBool("open", true);
            }
        }
        
         //Key trigger
        if(col.gameObject.name == "Key Trigger")
        {
            Debug.Log("touching key");
            triggerEnteredKey = true;
            
        }
        //Lime trigger
        if(col.gameObject.name == "Lime Trigger")
        {
            Debug.Log("touching lime");
            triggerEnteredLime = true;
            
        }
    }
    
    void OnTriggerExit (Collider col)
    {
        // We reset this variable since character is no longer in the trigger
        
        Debug.Log("trigger exited");
        
        
        //Key trigger
        if(col.gameObject.name == "Key Trigger")
        {
            Debug.Log("not touching key");
            triggerEnteredKey = false;
            
        }
        //Lime trigger
        if(col.gameObject.name == "Lime Trigger")
        {
            Debug.Log("not touching lime");
            triggerEnteredLime = false;
            
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
