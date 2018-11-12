//Attach this script to your GameObject (make sure it has a Renderer component)
//Click on the GameObject. Attach your own Textures in the GameObject’s Inspector.

//This script takes your GameObject’s material and changes its Normal Map, Albedo, and Metallic properties to the Textures you attach in the GameObject’s Inspector. This happens when you enter Play Mode

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{

    //Set these Textures in the Inspector
    Renderer m_Renderer;
    public Texture m_MainTexture;

    public bool meatTextureChanged;
    float currentTime;

    // Use this for initialization
    void Start()
    {
        //Fetch the Renderer from the GameObject
        m_Renderer = GetComponent<Renderer>();

        meatTextureChanged = false;
    }

    private void Update()
    {
        //Debug.Log("CurrentTime" + currentTime);
        //Debug.Log("DeltaTime" + Time.fixedTime);

        if (Time.fixedTime - currentTime >= 3 && currentTime > 0)
        {
            m_Renderer.material.SetTexture("_MainTex", m_MainTexture);
            meatTextureChanged = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stove")
        {
            print("collided stove");
            currentTime = Time.fixedTime;
        }
    }
}