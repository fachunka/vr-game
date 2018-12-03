using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVegChange : MonoBehaviour {

    public float status;

    void Start()
    {
        status = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.tag == "GameController")
        {
            status += 1;
        }

    }
}