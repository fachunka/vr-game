using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeFoodDispenserCategoryVeg : MonoBehaviour {
    public GameObject gameObContainingScript;
    Renderer m_Renderer;
    public Texture m_LimeTexture;
    public Texture m_CornmealTexture;
    public Texture m_MirendaTexture;
    public Texture m_BananaTexture;


    public bool porkTextureChanged;
    public bool chickenTextureChanged;
    
    // Use this for initialization
    void Start () 
    {
        m_Renderer = GetComponent<Renderer>();

        //porkTextureChanged = false;
    }

    // Update is called once per frame
    void Update()
    {
        ButtonVegChange ButtonVegChangeScript = gameObContainingScript.GetComponent<ButtonVegChange>();

        if (ButtonVegChangeScript.status % 4 == 0)
        {
            //print("change to pork texture");
            m_Renderer.material.SetTexture("_MainTex", m_LimeTexture);
            //porkTextureChanged = true;
            //print("PushButtonFoodDispenserScript: " + ButtonVegChangeScript.status % 4);

            gameObject.SendMessage("playVegiScreen", 1f);     // play beep (call playVegiScreen function with float 1 in vegiScreenAudio.cs script)
        }
        else if (ButtonVegChangeScript.status % 4 == 1)
        {
            //print("change to chicken texture");
            m_Renderer.material.SetTexture("_MainTex", m_CornmealTexture);

            gameObject.SendMessage("playVegiScreen", 2f);     // play beep (call playVegiScreen function with float 2 in vegiScreenAudio.cs script)
            //print("PushButtonFoodDispenserScript: " + ButtonVegChangeScript.status % 4);

        }
        else if (ButtonVegChangeScript.status % 4 == 2)
        {
            //print("change to chicken texture");
            m_Renderer.material.SetTexture("_MainTex", m_MirendaTexture);

            gameObject.SendMessage("playVegiScreen", 3f);     // play beep (call playVegiScreen function with float 3 in vegiScreenAudio.cs script)
            //print("PushButtonFoodDispenserScript: " + ButtonVegChangeScript.status % 4);

        }
        else if (ButtonVegChangeScript.status % 4 == 3)
        {
            //print("change to chicken texture");
            m_Renderer.material.SetTexture("_MainTex", m_BananaTexture);

            gameObject.SendMessage("playVegiScreen", 4f);     // play beep (call playVegiScreen function with float 4 in vegiScreenAudio.cs script)
            //print("PushButtonFoodDispenserScript: " + ButtonVegChangeScript.status % 4);

        }


    }
 }
