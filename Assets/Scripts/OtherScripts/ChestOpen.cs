using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public GameObject chestHalf;

    public bool chestHalfOpened;
    // Use this for initialization
    void Start()
    {
        chestHalfOpened = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Key")
        {
            Debug.Log("chest half opened");

            chestHalf = Instantiate(chestHalf, transform.position, Quaternion.identity) as GameObject;
            //destroy closed chest
            Destroy(gameObject);
            //drop Key from hand;

            chestHalfOpened = true;
        }
    }
}
