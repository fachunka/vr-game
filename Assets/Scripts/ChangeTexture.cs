//Attach this script to your GameObject (make sure it has a Renderer component)
//Click on the GameObject. Attach your own Textures in the GameObject’s Inspector.

//This script takes your GameObject’s material and changes its Normal Map, Albedo, and Metallic properties to the Textures you attach in the GameObject’s Inspector. This happens when you enter Play Mode

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{

    //Set these Textures in the Inspector
    public Texture m_MainTexture;
    Renderer m_Renderer;

    // Use this for initialization
    void Start()
    {
        //Fetch the Renderer from the GameObject
        m_Renderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stove")
        {
            m_Renderer.material.SetTexture("_MainTex", m_MainTexture);
            //create cute object called lime
            //Debug.Log("button pushed");
            //GameObject Lime = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //Lime.AddComponent<Rigidbody>();
            //Lime.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            //Lime.transform.position = new Vector3(-2, 2, 0.2f);
        }
    }
}