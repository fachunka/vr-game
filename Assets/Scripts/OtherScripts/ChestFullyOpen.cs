using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestFullyOpen : MonoBehaviour
{

    public GameObject chestFully;

    public bool chestFullyOpened;
    // Use this for initialization
    void Start()
    {
        chestFullyOpened = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Lime")
        {
            Debug.Log("chest fully opened");

            chestFully = Instantiate(chestFully, transform.position, Quaternion.identity) as GameObject;
            //destroy half opened chest
            Destroy(gameObject);
            //drop Lime from hand;

            chestFullyOpened = true;
        }
    }
}
