using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkButton : MonoBehaviour
{
    public Material material;

    public bool turnOnBlinkButton;

    void Start()
    {
        turnOnBlinkButton = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Mathf.Ceil(Time.fixedTime));

        if (turnOnBlinkButton == true)
        {
            if (Mathf.Ceil(Time.fixedTime) % 2 == 0)
            {
                material.EnableKeyword("_EMISSION");
            }
            else
            {
                material.DisableKeyword("_EMISSION");
            }
        }
    }

}
