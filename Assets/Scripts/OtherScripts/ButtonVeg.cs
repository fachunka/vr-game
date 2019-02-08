using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVeg : MonoBehaviour {

    public GameObject lime;
    public GameObject cornMeal;
    public GameObject mirandaLeaf;
    public GameObject banana;
    public GameObject dispenserVeg;

    public GameObject gameObContainingScript;

    public Vector3 positionAdjust;

    public float printTime = 1.5f;
    private GameObject vegiDispenserAudioSource;

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
            ButtonVegChange ButtonVegChangeScript = gameObContainingScript.GetComponent<ButtonVegChange>();

            if (other.gameObject.tag == "GameController")
            {
                if (ButtonVegChangeScript.status % 4 == 0)
                {
                    StartCoroutine(printLime());
                    vegiDispenserAudioSource = GameObject.Find("Dispenser_vegi");
                    vegiDispenserAudioSource.SendMessage("playPrintFood");
                }

                else if (ButtonVegChangeScript.status % 4 == 1)
                {
                    StartCoroutine(printCornMeal());
                    vegiDispenserAudioSource = GameObject.Find("Dispenser_vegi");
                    vegiDispenserAudioSource.SendMessage("playPrintFood");
                }

                else if (ButtonVegChangeScript.status % 4 == 2)
                {
                    StartCoroutine(printMirandaLeaf());
                    vegiDispenserAudioSource = GameObject.Find("Dispenser_vegi");
                    vegiDispenserAudioSource.SendMessage("playPrintFood");
                }

                else if (ButtonVegChangeScript.status % 4 == 3)
                {
                    StartCoroutine(printBanana());
                    vegiDispenserAudioSource = GameObject.Find("Dispenser_vegi");
                    vegiDispenserAudioSource.SendMessage("playPrintFood");
                }

            }
        }
    }


        IEnumerator printLime()
        {
            yield return new WaitForSeconds(printTime);
            Instantiate(lime, dispenserVeg.transform.position + positionAdjust, Quaternion.identity);
            yield return (0);
        }

        IEnumerator printCornMeal()
        {
            yield return new WaitForSeconds(printTime);
            Instantiate(cornMeal, dispenserVeg.transform.position + positionAdjust, Quaternion.identity);
            yield return (0);
        }

        IEnumerator printMirandaLeaf()
        {
            yield return new WaitForSeconds(printTime);
            Instantiate(mirandaLeaf, dispenserVeg.transform.position + positionAdjust, Quaternion.identity);
            yield return (0);
        }

        IEnumerator printBanana()
        {
            yield return new WaitForSeconds(printTime);
            Instantiate(banana, dispenserVeg.transform.position + positionAdjust, Quaternion.identity);
            yield return (0);
        }

}