using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject chestHalf;


    private bool keyInBox = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (keyInBox == true)
        {
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "boxClosedPrefab")
        {
            keyInBox = true;
            print("collided key");

            chestHalf = Instantiate(chestHalf, transform.position, Quaternion.identity) as GameObject;
            Destroy(GameObject.Find("boxHalfOpenPrefab"));
        }

    }
}
