using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLime : MonoBehaviour {

    public GameObject lime;
    public GameObject dispenserVeg;

    public GameObject gameObContainingScript;
    public GameObject gameObContainingScriptTwo;

    public Vector3 positionAdjust;

    public float printTime = 1.5f;
    private GameObject vegiDispenserAudioSource;

    private bool controllerTouching;

    // Use this for initialization
    void Start()
    {
        positionAdjust = new Vector3(0, 0.26f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObContainingScript && gameObContainingScriptTwo)
        {
            ButtonVegChange ButtonVegChangeScript = gameObContainingScript.GetComponent<ButtonVegChange>();
            ControllerGrabObject triggerDownScript = gameObContainingScriptTwo.GetComponent<ControllerGrabObject>();

            Debug.Log(triggerDownScript.triggerDown);


                if (triggerDownScript.triggerDown == true)
                 {
                    if (controllerTouching == true) {
 

                                StartCoroutine(printLime());
                                vegiDispenserAudioSource = GameObject.Find("Dispenser_fish");
                                vegiDispenserAudioSource.SendMessage("playPrintFood");

                    
                        triggerDownScript.triggerDown = false;


                    }


            }
        }

    }

    //when the player touches button create lime
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "GameController")
        {
            controllerTouching = true;
        }


    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "GameController")
        {
            controllerTouching = false;
        }


    }


    IEnumerator printLime()
        {
            yield return new WaitForSeconds(printTime);
            Instantiate(lime, dispenserVeg.transform.position + positionAdjust, Quaternion.identity);
            yield return (0);
        }


}