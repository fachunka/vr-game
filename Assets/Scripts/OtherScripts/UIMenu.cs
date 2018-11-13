using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{

    public Canvas UICanvas;
    public GameObject gameObContainingScript;

    bool enableScriptAppear;

    // Use this for initialization
    void Start()
    {
        //enableScriptAppear = false;
        UICanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //MonsterPlantResize MonsterPlantResizeScript = gameObContainingScript.GetComponent<MonsterPlantResize>();
        //if(MonsterPlantResizeScript.monsterFeeded == true)
        //{
        //    enableScriptAppear = true;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(enableScriptAppear == true)
        //{
            UICanvas.enabled = true;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        UICanvas.enabled = false;
    }
}
