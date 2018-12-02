using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButtonFoodDispenser2 : MonoBehaviour {

    public GameObject lime;
    public GameObject cornMeal;
    public GameObject mirandaLeaf;
    public GameObject banana;

    public float printTime = 1.5f;

    private GameObject vegiDispenserAudioSource;
    
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
        if (other.gameObject.tag == "ButtonVeg")
        {
            if (status % 4 == 0)
            {
                StartCoroutine(printLime());
//                Instantiate(lime, transform.position + positionAdjust, Quaternion.identity);
            }

            else if (status % 4 == 1)
            {
                StartCoroutine(printCornMeal());
//                Instantiate(cornMeal, transform.position + positionAdjust, Quaternion.identity);
            }

            else if (status % 4 == 2)
            {
                StartCoroutine(printMirandaLeaf());
//                Instantiate(mirandaLeaf, transform.position + positionAdjust, Quaternion.identity);
            }

            else if (status % 4 == 3)
            {
                StartCoroutine(printBanana());
//                Instantiate(banana, transform.position + positionAdjust, Quaternion.identity);
            }

        }

        if (other.gameObject.tag == "ButtonCategoryVeg")
        {
            status += 1;
        }

    }

    IEnumerator printLime()
    {
        vegiDispenserAudioSource = GameObject.Find("Dispenser_vegi");
        vegiDispenserAudioSource.SendMessage("playPrintFood");

        yield return new WaitForSeconds(printTime);
        Instantiate(lime, transform.position + positionAdjust, Quaternion.identity);
        yield return(0);
    }

    IEnumerator printCornMeal()
    {
        vegiDispenserAudioSource = GameObject.Find("Dispenser_vegi");
        vegiDispenserAudioSource.SendMessage("playPrintFood");

        yield return new WaitForSeconds(printTime);
        Instantiate(cornMeal, transform.position + positionAdjust, Quaternion.identity);
        yield return(0);
    }

    IEnumerator printMirandaLeaf()
    {
        vegiDispenserAudioSource = GameObject.Find("Dispenser_vegi");
        vegiDispenserAudioSource.SendMessage("playPrintFood");

        yield return new WaitForSeconds(printTime);
        Instantiate(mirandaLeaf, transform.position + positionAdjust, Quaternion.identity);
        yield return(0);
    }

    IEnumerator printBanana()
    {
        vegiDispenserAudioSource = GameObject.Find("Dispenser_vegi");
        vegiDispenserAudioSource.SendMessage("playPrintFood");

       yield return new WaitForSeconds(printTime);
        Instantiate(banana, transform.position + positionAdjust, Quaternion.identity);
        yield return(0);
    }

}