using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorCollider : MonoBehaviour {
    
    public bool inLift = false;
    public GameObject Lift;
    
    void Start()
    {
        Lift = GameObject.Find("Lift");
    }
    
    void FixedUpdate()
    {
        if(inLift){
        transform.parent.position -= transform.up * Time.deltaTime;
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
            Debug.Log("you're now in a lift");
        }
    }
}
