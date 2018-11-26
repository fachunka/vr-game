using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMeatChunk : MonoBehaviour
{
    //    public GameObject remains;
    bool touchingPlant;

    // Use this for initialization
    void Start()
    {
        touchingPlant = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (touchingPlant == true)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "MonsterPlant")
        {
            touchingPlant = true;
        }
    }
}
