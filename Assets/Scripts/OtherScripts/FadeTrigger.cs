using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTrigger : MonoBehaviour {
    
    public bool fadeNow;
    
    void Start () {
        fadeNow = false;
    }

    void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.tag == "GameController")
        {
            fadeNow = true;
//            Debug.Log("fadey");
        }
    }

}
