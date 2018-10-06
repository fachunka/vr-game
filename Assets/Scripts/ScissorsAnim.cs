using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//scissors moving
public class ScissorsAnim : MonoBehaviour {

    public Animator scissorAni;

    // Use this for initialization
    void Start()
    {
        scissorAni.enabled = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "GameController")
        {
            scissorAni.enabled = true;
            Debug.Log("Hello");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "GameController")
        {
            scissorAni.enabled = false;
            Debug.Log("Goodbye");
        }
    }
}
