using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFood : MonoBehaviour {

    public GameObject food;
    public GameObject outputPos;
	public GameObject gameObContainingScript;
    public GameObject gameObContainingScriptTwo;
    public float printTime = 1.0f;
    private GameObject dispenserAudioSource;

    private bool controllerTouching;


    // Update is called once per frame
    void Update()
    {
        if (gameObContainingScript && gameObContainingScriptTwo)
        {

            ControllerGrabObject triggerDownScript = gameObContainingScriptTwo.GetComponent<ControllerGrabObject>();

                if (triggerDownScript.triggerDown == true)
                 {
                    if (controllerTouching == true) {
 
                                StartCoroutine(printFood());
                                dispenserAudioSource = gameObContainingScript;
                                dispenserAudioSource.SendMessage("playPrintFood");

                    
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


    IEnumerator printFood()
        {
            yield return new WaitForSeconds(printTime);
            Instantiate(food, outputPos.transform.position, Quaternion.identity);
            yield return (0);
        }


}