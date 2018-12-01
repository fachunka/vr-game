using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButtonFoodDispenser : MonoBehaviour
{
    public GameObject pork;
    public GameObject chikenDrum;
    public GameObject fish;
    public GameObject lime;
    private GameObject meatDispenserAudioSource;

    public float status;

    public Vector3 positionAdjust;

    // Use this for initialization
    void Start()
    {
        positionAdjust = new Vector3(-0.175f, 0, -0.175f);

        status = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //when the player touches button create lime
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Button")
        {
            if (status % 4 == 0)
            {
                //create pork prefab
                Instantiate(pork, transform.position + positionAdjust, Quaternion.identity);
                meatDispenserAudioSource = GameObject.Find("Dispenser_meat");
                meatDispenserAudioSource.SendMessage("playPrintFood");
            }

            else if(status % 4 == 1)
            {
                Instantiate(chikenDrum, transform.position + positionAdjust, Quaternion.identity);
                meatDispenserAudioSource = GameObject.Find("Dispenser_meat");
                meatDispenserAudioSource.SendMessage("playPrintFood");
            }

            else if (status % 4 == 2)
            {
                Instantiate(fish, transform.position + positionAdjust, Quaternion.identity);
                meatDispenserAudioSource = GameObject.Find("Dispenser_meat");
                meatDispenserAudioSource.SendMessage("playPrintFood");
            }

            else if (status % 4 == 3)
            {
                Instantiate(lime, transform.position + positionAdjust, Quaternion.identity);
                meatDispenserAudioSource = GameObject.Find("Dispenser_meat");
                meatDispenserAudioSource.SendMessage("playPrintFood");
            }

        }

        if (other.gameObject.tag == "ButtonCategory")
        {
            status += 1;
        }

    }
}