using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour {

    private Animator handAnim;
    //public GameObject check;

    // Use this for initialization
    void Start () 
    {
        handAnim = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame

	void Update () 
    {

        if (gameObject.GetComponent<ControllerGrabObject>().onTriggerEnterActivated == true)
        {
            if (!(handAnim.GetBool("IsGrabbing")))
            {
                handAnim.SetBool("IsGrabbing", true);
            }
        }

        else
        {
            if (handAnim.GetBool("IsGrabbing"))
            {
       
                handAnim.SetBool("IsGrabbing", false);
            }
        }


    }
}
