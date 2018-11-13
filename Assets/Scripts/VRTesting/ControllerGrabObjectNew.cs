using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerGrabObjectNew : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;


    //GameObjects
    private GameObject rightHand;
    public GameObject key;
    public GameObject lime;
    public GameObject lidopen;
    private GameObject collidingObject;
    public GameObject objectInHand;

    //Current Object Name
    private string currentObj;

    //HandAnimation
    public bool onTriggerEnterActivated = false;

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
  
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }

        collidingObject = col.gameObject;
    }



    public void OnTriggerEnter(Collider other)
    {
//        Debug.Log("trigger pressed");

        //HandAnimation
        onTriggerEnterActivated = true;
        //

        SetCollidingObject(other);
    }


    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;

        //HandAnimation
        onTriggerEnterActivated = false;
        //
    }


    void Update()
    {
        if (Controller.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
        if (objectInHand){

                if (objectInHand.gameObject.name == "Key"){
                    Debug.Log(objectInHand.gameObject.name);
                }
        }
    }

    public void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }

        objectInHand = null;
    }
}
