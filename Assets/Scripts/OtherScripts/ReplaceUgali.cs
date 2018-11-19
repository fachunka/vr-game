using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//if three items are placed over the stove, initiatate ugali dish
public class ReplaceUgali : MonoBehaviour
{
    public GameObject Ugali;
    bool replaceObjects;

    // Use this for initialization
    void Start()
    {
        replaceObjects = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //if colliding with corn & chicken & key?
        if (other.gameObject.tag == "Key" && other.gameObject.tag == "Key" && other.gameObject.tag == "Key")
        {
            //and if button has been pressed
            //if ()
            //{
                replaceObjects = true;
                GameObject ugali = Instantiate(Ugali, transform.position, transform.rotation) as GameObject;
            //}
        }
    }
}
