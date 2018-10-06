using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour {
    
    public Animator ani;

	// Use this for initialization
	void Start () {

        ani.enabled = false;
	}
	
    void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.tag == "GameController")
        {
            ani.enabled = true;
            Debug.Log("Hello");
        }
    }
    
    void OnTriggerExit (Collider col)
    {
        if(col.gameObject.tag == "GameController")
        {
            ani.enabled = false;
            Debug.Log("Goodbye");
        }
    }
}
