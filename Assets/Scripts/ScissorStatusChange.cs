using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorStatusChange : MonoBehaviour
{
    public GameObject GameObject;
    private ControllerGrabObject ControllerGrabObject;
    bool grabScissors = false;


    [SerializeField]
    private GameObject scissors;
   
    private void Start()
    {
        ControllerGrabObject = GameObject.GetComponent<ControllerGrabObject>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider col)
    {
        //output the collider's gameobject's name
        //Debug.Log(collision.collider.name);

        if(col.tag == "ScissorAnimateTrigger")
        {
            Debug.Log("scissors collided with the cube");
            GameObject objectInHandScissor = Instantiate(scissors, ControllerGrabObject.transform.position, transform.rotation) as GameObject;
            objectInHandScissor.transform.parent = null;
            ControllerGrabObject.objectInHand = objectInHandScissor;

            //objectInHandScissor.GetComponent<ControllerGrabObject>()GrabObject(ControllerGrabObject);
        }
    }
}
 