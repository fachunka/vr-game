using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//access shader property and make them resize continuosly
//reference https://www.youtube.com/watch?v=tsKWT5KZ_qs

public class OutlineControl : MonoBehaviour
{
    public Renderer meshRenderer;
    public Material instancedMaterial;

    //GameObject to get FreeElevatorLevel1 Script
    public GameObject gameObContainingScript;

    public float interpolationSpeed;

    // animate the game object from 1.0 to 1.1 and back
    float minimum = 1.01f;
    float maximum = 1.1f;

    // starting value for the Lerp
    static float t = 0.0f;

    // Use this for initialization
    private void Start()
    {
        meshRenderer = gameObject.GetComponent<Renderer>();
        instancedMaterial = meshRenderer.material;

        interpolationSpeed = 1.45f;
    }

    // Update is called once per frame
    void Update()
    {
        float dissolveAmount = Mathf.Lerp(minimum, maximum, t);
        t += interpolationSpeed * Time.deltaTime;
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }

        instancedMaterial.SetFloat("_OutlineWidth", dissolveAmount);

        //----------------------------------------------------------------------
        //remove outline when all puzzle solved
        FreeElevatorLevel1 FreeElevatorLevel1Script = gameObContainingScript.GetComponent<FreeElevatorLevel1>();

        if (FreeElevatorLevel1Script.freeAll == true || Input.GetKeyDown("o"))
        {
            //minimum = 0;
            //maximum = 0;
        }
    }

}
