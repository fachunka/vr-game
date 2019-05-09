using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutleryDoor : MonoBehaviour {


    //key variables
    public bool keyed = false;
    public GameObject toReplace;
    private Vector3 slightlyOpenPos;
    private int BoxKey = 0;

    //lime variables
    private bool limed = false;
    private bool slightlyOpen = false;
    private int LimedBox = 0;
    //public GameObject scissorsBox;
    //public GameObject knifeBox;
    //public GameObject forkBox;
    //private Vector3 scissorsPos;
    //private Vector3 knifePos;
    //private Vector3 forkPos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // print(this.transform.parent.transform.position);
        // print(this.transform.parent.name);

        BoxKey = PlayerPrefs.GetInt("BoxKey");

        if (BoxKey == 1 && slightlyOpen == false)
        {
            transform.localRotation = Quaternion.Euler(0f, -96.0f, 0f);
            slightlyOpen = true;
        }

        // print(this.transform.parent.transform.position);
        // print(this.transform.parent.name);

        LimedBox = PlayerPrefs.GetInt("LimedBox");

        //Debug.Log(LimedBox);
        if (LimedBox == 1 && slightlyOpen == true)
        {

            //scissorsPos = this.transform.parent.transform.position;
            //knifePos = this.transform.parent.transform.position;
            //forkPos = this.transform.parent.transform.position;
            ////scissorsPos.y += 0.1f;
            //scissorsPos.z -= 0.1f;
            ////forkPos.x += 0.1f;
            //// forkPos.y += 0.1f;
            //forkPos.z -= 0.1f;
            //// knifePos.x -= 0.1f;
            ////knifePos.y += 0.1f;
            //knifePos.z -= 0.1f;


            transform.localRotation = Quaternion.Euler(0f, -240.0f, 0f);



            //Instantiate(scissorsBox, scissorsPos, Quaternion.identity);
            //Instantiate(forkBox, scissorsPos, Quaternion.identity);
            //Instantiate(knifeBox, scissorsPos, Quaternion.identity);
            print("limed");

        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            //keyed = true;
            PlayerPrefs.SetInt("BoxKey", 1);
            print("collided key");
        }

        if (other.gameObject.tag == "Lime")
        {
            PlayerPrefs.SetInt("LimedBox", 1);
            limed = true;
            print("collided lime");

        }

    }
}
