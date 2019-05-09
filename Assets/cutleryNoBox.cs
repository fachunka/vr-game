using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutleryNoBox : MonoBehaviour
{

    public bool keyed = false;
    public GameObject toReplace;
    private Vector3 slightlyOpenPos;
    private int BoxKey = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // print(this.transform.parent.transform.position);
        // print(this.transform.parent.name);

        BoxKey = PlayerPrefs.GetInt("BoxKey");

        if (BoxKey == 1)
        {
            slightlyOpenPos = this.transform.parent.transform.position;

            Destroy(this.transform.parent.gameObject);

            Instantiate(toReplace, new Vector3(0.05f, 0.45f, 0.65f), Quaternion.Euler(new Vector3(0, 0, 0)));
            //print("keyed");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            //keyed = true;
            PlayerPrefs.SetInt("BoxKey", 1);
            //print("collided key");
        }

    }
}
