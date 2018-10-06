using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{

    [SerializeField]
    private GameObject remains;
    private GameObject objectInHand;

    ControllerGrabObject controllerGrabObject = new ControllerGrabObject();

    private void Start()
    {
    }

    //check if grabbed objected was scissor by tagging
    //scissor crossing the box (coordination) or just touching the collider, box breaks
    private void OnCollisionEnter(Collision collision)
    {
        //output the collider's gameobject's name
        Debug.Log(collision.collider.name);

        //if grabbing object is scissors
        //if(controllerGrabObject.objectInHand.gameObject.tag == "Scissors")
        //{
        //    Debug.Log("scissors grabbed");
        //}

        //if scissors collide with cube
        if(collision.gameObject.tag == "Cube")
        {
            Debug.Log("sxcissors collided with the cube");

            Instantiate(remains, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
