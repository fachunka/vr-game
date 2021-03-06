using UnityEngine;

public class ControllerGrabObject : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;

    public GameObject collidingObject;
    public GameObject objectInHand;
    public string objectInHandName;

    //HandAnimation, added by Jung
    public bool onTriggerEnterActivated = false;
    public bool GetOutStoryScene = false;
    //

    //figure out whether object is released and sends it to returnPosition script, added by Jung
    public bool releasedObject = false;
    //

    public bool triggerDown;

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

            //added by Jung
            releasedObject = false;
            GetOutStoryScene = true;
            //

            triggerDown = true;
           // Debug.Log("trigger is down");
        }

        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
            }

            //added by Jung
            triggerDown = false;
            releasedObject = true;
            //
        }

        //added by Jung to execute 'change mode of the scissor'
        //if ()
        //{
        //    ReleaseObject();
        //}
        //
    }

    public void GrabObject()
    {
        objectInHand = collidingObject;
        objectInHandName = collidingObject.name;
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
        objectInHandName = null;
    }

    //added by Jung to execute 'MonsterSpitObjectNotSim'
    public void ReleaseObjectControlledByOtherScript()
    {
        ReleaseObject();
    }
    //
}
