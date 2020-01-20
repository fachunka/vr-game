using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyInTheDoor : MonoBehaviour {

    public Renderer rend;
    private int BoxKey;

    // Use this for initialization
    void Start () {

        rend = GetComponent<Renderer>();
        rend.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {


        BoxKey = PlayerPrefs.GetInt("BoxKey");

        if (BoxKey == 1)
        {
            rend.enabled = true;
        }

    }
}
