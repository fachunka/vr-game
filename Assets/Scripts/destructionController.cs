using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructionController : MonoBehaviour
{

    //    public GameObject remains;

    [SerializeField]
    private GameObject remains;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update () {
           if (Input.GetKey("space"))
           {
               Instantiate(remains, transform.position, transform.rotation);
               Destroy(gameObject);
           }

    }

    void OnTriggerEnter(Collider col)
    {
        //if(col.gameObject.tag == "GameController")

        //when scissors collide with meat, it breaks down into three pieces
        if (col.gameObject.tag == "Scissors")
        {
            Instantiate(remains, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
