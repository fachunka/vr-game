﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeFoodDispenserCategory : MonoBehaviour {
    public GameObject gameObContainingScript;
    Renderer m_Renderer;
    public Texture m_PorkTexture;
    public Texture m_ChickenTexture;

    public bool porkTextureChanged;
    public bool chickenTextureChanged;
    
    // Use this for initialization
    void Start () 
    {
        m_Renderer = GetComponent<Renderer>();

        porkTextureChanged = false;
    }

    // Update is called once per frame
    void Update ()
    {
        PushButtonFoodDispenser PushButtonFoodDispenserScript = gameObContainingScript.GetComponent<PushButtonFoodDispenser>();
        if (PushButtonFoodDispenserScript.status % 2 == 0)
        {
            //print("change to pork texture");
            m_Renderer.material.SetTexture("_MainTex", m_PorkTexture);
            porkTextureChanged = true;
        }
        else
        {
            //print("change to chicken texture");
            m_Renderer.material.SetTexture("_MainTex", m_ChickenTexture);
        }
    }
}