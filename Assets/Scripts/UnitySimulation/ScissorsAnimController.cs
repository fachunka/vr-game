using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsAnimController : MonoBehaviour
{
    public Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Meat(Clone)")
        {
            print("touching Meat(Clone)");
            anim.Play("Scissors2");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Meat(Clone)")
        {
            anim.Play("Not Moving State");
        }
    }
}
