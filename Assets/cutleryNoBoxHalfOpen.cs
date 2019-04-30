using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutleryNoBoxHalfOpen : MonoBehaviour
{

    private bool limed = false;
    private int LimedBox = 0;

    public GameObject toReplace;
    public GameObject scissorsBox;
    public GameObject knifeBox;
    public GameObject forkBox;

    private Vector3 slightlyOpenPos;
    private Vector3 scissorsPos;
    private Vector3 knifePos;
    private Vector3 forkPos;

    void Update()
    {
        // print(this.transform.parent.transform.position);
        // print(this.transform.parent.name);

        LimedBox = PlayerPrefs.GetInt("LimedBox");

        if (LimedBox == 1)
        {

            slightlyOpenPos = this.transform.parent.transform.position;
            scissorsPos = new Vector3(0.07f, 0.45f, 0.65f);
            knifePos = new Vector3(0.05f, 0.45f, 0.65f);
            forkPos = new Vector3(0.03f, 0.45f, 0.65f);

            Destroy(this.transform.parent.gameObject);

            Instantiate(toReplace, slightlyOpenPos, Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(scissorsBox, scissorsPos, Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(forkBox, forkPos, Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(knifeBox, knifePos, Quaternion.Euler(new Vector3(0, 0, 0)));
            //print("limed");
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Lime")
        {
            PlayerPrefs.SetInt("LimedBox", 1);
            limed = true;
            //print("collided lime");

        }
    }
}
