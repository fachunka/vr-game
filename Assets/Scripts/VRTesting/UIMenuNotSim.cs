using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuNotSim : MonoBehaviour {

    public Canvas UICanvas;
    public Canvas UICanvasMainUI;
    public GameObject gameObContainingScript;

    bool enableScriptAppear;

    // Use this for initialization
    void Start()
    {
        //code for canvasRecipe
        enableScriptAppear = false;
        UICanvas.enabled = false;

        //code for canvasMainUI
        UICanvasMainUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        MonsterPlantResizeNotSim MonsterPlantResizeNotSimeScript = gameObContainingScript.GetComponent<MonsterPlantResizeNotSim>();
        if (MonsterPlantResizeNotSimeScript.monsterFeeded == true)
        {
            enableScriptAppear = true;
        }

        //print(UICanvas.enabled);
    }

    private void OnTriggerEnter(Collider other)
    {
        //code for canvasRecipe
        if (enableScriptAppear == true)
        {
            if (other.gameObject.tag == "GameController")
            {
                UICanvas.enabled = true;
            }
        }

        //code for canvasMainUI, if the rotating ball collides with key object, then enable the canvasMainUI
        //if (other.gameObject.tag == ("Key"))
        //{
        //    UICanvasMainUI.enabled = true;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //code for canvasRecipe
        UICanvas.enabled = false;

        //code for canvasMainUI
        //if (other.gameObject.tag == ("Key"))
        //{
        //    UICanvasMainUI.enabled = false;
        //}
    }
}
