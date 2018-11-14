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
        enableScriptAppear = false;
        UICanvas.enabled = false;

        //if (UICanvas.enabled == false)
        //{
        //    RectTransform rt = UICanvas.GetComponent(typeof(RectTransform)) as RectTransform;
        //    rt.sizeDelta = new Vector2(0, 0);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        MonsterPlantResize MonsterPlantResizeScript = gameObContainingScript.GetComponent<MonsterPlantResize>();
        if(MonsterPlantResizeScript.monsterFeeded == true)
        {
            enableScriptAppear = true;
        }

        //print(UICanvas.enabled);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(enableScriptAppear == true)
        {
            UICanvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        UICanvas.enabled = false;
    }
}
