using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //public GameObject gameObContainingScript;
    private int BoxKey;

    void Start()
    {
    }

    void Update()
    {

        BoxKey = PlayerPrefs.GetInt("BoxKey");


        //cutleryBox cutleryBox1Script = gameObContainingScript.GetComponent<cutleryBox>();

        if (BoxKey == 1)
        {
            print("Key destroyed?");

            Destroy(this.gameObject);

        }


    }

}
