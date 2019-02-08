using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeFoodDispenserCategory : MonoBehaviour {
    public GameObject gameObContainingScript;
    Renderer m_Renderer;
    public Texture m_PorkTexture;
    public Texture m_ChickenTexture;
    public Texture m_FishTexture;

    // Use this for initialization
    void Start () 
    {
        m_Renderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update ()
    {
        ButtonMeatChange ButtonMeatChangeScript = gameObContainingScript.GetComponent<ButtonMeatChange>();
        if (ButtonMeatChangeScript.status % 3 == 0)
        {
            m_Renderer.material.SetTexture("_MainTex", m_PorkTexture);

            gameObject.SendMessage("playMeatScreen", 1f);     // play beep (call playMeatScreen function with float 1 in meatScreenAudio.cs script)
        }
        else if (ButtonMeatChangeScript.status % 3 == 1)
        {
            m_Renderer.material.SetTexture("_MainTex", m_ChickenTexture);

            gameObject.SendMessage("playMeatScreen", 2f);     // play beep (call playMeatScreen function with int 2 in meatScreenAudio.cs script)

        }

        else if (ButtonMeatChangeScript.status % 3 == 2)
        {
            m_Renderer.material.SetTexture("_MainTex", m_FishTexture);

            gameObject.SendMessage("playMeatScreen", 3f);     // play beep (call playMeatScreen function with int 3 in meatScreenAudio.cs script)

        }
    }
}
