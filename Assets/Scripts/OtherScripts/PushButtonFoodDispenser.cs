using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButtonFoodDispenser : MonoBehaviour
{
    public GameObject pork;
    public GameObject chikenDrum;
    public GameObject fish;
    public GameObject dispenserMeat;

    public float printTime = 3.0f;

    private GameObject meatDispenserAudioSource;

    public float status;

    public Vector3 positionAdjust;

    // Use this for initialization
    void Start()
    {
        positionAdjust = new Vector3(0, 0.26f, 0);

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
            if (status % 3 == 0)
            {
                //create pork prefab
                StartCoroutine(printPork());
//                Instantiate(pork, transform.position + positionAdjust, Quaternion.identity);
                meatDispenserAudioSource = GameObject.Find("Dispenser_meat");
                meatDispenserAudioSource.SendMessage("playPrintFood");
            }

            else if(status % 3 == 1)
            {
                StartCoroutine(printChicken());
//                Instantiate(chikenDrum, transform.position + positionAdjust, Quaternion.identity);
                meatDispenserAudioSource = GameObject.Find("Dispenser_meat");
                meatDispenserAudioSource.SendMessage("playPrintFood");
            }

            else if (status % 3 == 2)
            {
                StartCoroutine(printFish());
//                Instantiate(fish, transform.position + positionAdjust, Quaternion.identity);
                meatDispenserAudioSource = GameObject.Find("Dispenser_meat");
                meatDispenserAudioSource.SendMessage("playPrintFood");
            }


        }

        if (other.gameObject.tag == "ButtonCategory")
        {
            status += 1;
        }

    }

    IEnumerator printPork()
    {
        yield return new WaitForSeconds(printTime);
        Instantiate(pork, dispenserMeat.transform.position + positionAdjust, Quaternion.identity);
        yield return(0);
    }

    IEnumerator printChicken()
    {
        yield return new WaitForSeconds(printTime);
        Instantiate(chikenDrum, dispenserMeat.transform.position + positionAdjust, Quaternion.identity);
        yield return(0);
    }

    IEnumerator printFish()
    {
        yield return new WaitForSeconds(printTime);
        Instantiate(fish, dispenserMeat.transform.position + positionAdjust, Quaternion.identity);
        yield return(0);
    }


}