using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIMenuNotSim : MonoBehaviour
{
    public Canvas UICanvasMainUI;
    public GameObject gameObContainingScript;

    bool enableScriptAppear;

    // Use this for initialization
    void Start()
    {
        enableScriptAppear = false;
        UICanvasMainUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ControllerGrabObject ControllerGrabObjectScript = gameObContainingScript.GetComponent<ControllerGrabObject>();

        //if object inhand is rotating ball
        ///if (MonsterPlantResizeNotSimeScript.monsterFeeded == true)
        //{
        //    enableScriptAppear = true;
        //}

        //print(UICanvas.enabled);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Key"))
        {
            UICanvasMainUI.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Key"))
        {
            UICanvasMainUI.enabled = false;
        }
    }
}
