using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject chestHalf;


    private bool keyInBox;

    // Use this for initialization
    void Start()
    {
        keyInBox = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (keyInBox == true)
        {
            print("destroyed?");
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "boxClosedPrefab")
        {
            keyInBox = true;
            print("collided key");

        }

    }
}
