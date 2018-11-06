using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorCollider : MonoBehaviour {
    
    private bool inLift = false;
    private GameObject Lift;
    
    void Start()
    {
        Lift = GameObject.Find("Lift");
    }
    
    void FixedUpdate()
    {
        if(inLift){
//        transform.position -= transform.up * Time.deltaTime;
        transform.root.position -= transform.up * Time.deltaTime;
        Lift.transform.position -= transform.up * Time.deltaTime;
//        Debug.Log("hi", Lift);
        }
    }
    
    void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.name == "Door")
        {
            SceneManager.LoadScene("SampleScene2");
        }
        if(col.gameObject.name == "Lift")
        {
            inLift = true;
//            Debug.Log("you're now in a lift");
        }
    }
}
