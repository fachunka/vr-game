using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsAnimControllerNotSim : MonoBehaviour {

    public Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Meat")
        {
            print("touching Meat, animating scissors");
            anim.Play("Scissors2");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Meat")
        {
            anim.Play("Not Moving State");
        }
    }
}
