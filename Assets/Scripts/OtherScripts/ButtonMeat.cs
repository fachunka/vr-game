using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMeat : MonoBehaviour {

    public GameObject pork;
    public GameObject chikenDrum;
    public GameObject fish;

    public GameObject dispenserMeat;

    public GameObject gameObContainingScript;

    public Vector3 positionAdjust;

    public float printTime = 1.5f;
    private GameObject meatDispenserAudioSource;

    // Use this for initialization
    void Start()
    {
        positionAdjust = new Vector3(0, 0.26f, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    //when the player touches button create lime
    void OnTriggerEnter(Collider other)
    {
        if (gameObContainingScript)
        {
            ButtonMeatChange ButtonMeatChangeScript = gameObContainingScript.GetComponent<ButtonMeatChange>();

            if (other.gameObject.tag == "GameController")
            {
                
                    if (ButtonMeatChangeScript.status % 3 == 0)
                    {
                        StartCoroutine(printPork());
                        meatDispenserAudioSource = GameObject.Find("Dispenser_meat");
                        meatDispenserAudioSource.SendMessage("playPrintFood");
                    }

                    else if (ButtonMeatChangeScript.status % 3 == 1)
                    {
                        StartCoroutine(printChicken());
                        meatDispenserAudioSource = GameObject.Find("Dispenser_meat");
                        meatDispenserAudioSource.SendMessage("playPrintFood");
                    }

                    else if (ButtonMeatChangeScript.status % 3 == 2)
                    {
                        StartCoroutine(printFish());
                        meatDispenserAudioSource = GameObject.Find("Dispenser_meat");
                        meatDispenserAudioSource.SendMessage("playPrintFood");
                    }
                }
        }
    }

        IEnumerator printPork()
        {
            yield return new WaitForSeconds(printTime);
            Instantiate(pork, dispenserMeat.transform.position + positionAdjust, Quaternion.identity);
            yield return (0);
        }

        IEnumerator printChicken()
        {
            yield return new WaitForSeconds(printTime);
            Instantiate(chikenDrum, dispenserMeat.transform.position + positionAdjust, Quaternion.identity);
            yield return (0);
        }

        IEnumerator printFish()
        {
            yield return new WaitForSeconds(printTime);
            Instantiate(fish, dispenserMeat.transform.position + positionAdjust, Quaternion.identity);
            yield return (0);
        }

    }