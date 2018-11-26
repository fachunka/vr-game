using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskSceneChange : MonoBehaviour {

    private bool masked;
    public string sceneName;
    private float fadeDuration = 2f;
    public GameObject fadeObject;


    // Use this for initialization
    void Start () {

        masked = false;
        //FadeToWhite();
        //Invoke("FadeFromWhite", fadeDuration);

    }

    private void FadeToWhite()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.white, fadeDuration);
    }

    private void FadeFromWhite()
    {
        //set start color
        SteamVR_Fade.Start(Color.white, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.clear, fadeDuration);
    }

    //Update is called once per frame
    void Update()
    {


        if (masked == true)
        {
            //RawImage fadeObjectScript = fadeObject.GetComponent<RawImage>();
            //fadeObjectScript.color = new Color(0, 0, 0, 1);
            //SteamVR_Fade.Start(Color.black, 20.25f);
            //SteamVR_LoadLevel.Begin(sceneName);
            FadeToWhite();
            //SteamVR_LoadLevel.Begin(sceneName);
            Invoke("FadeFromWhite", fadeDuration);

        }

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "GameController")
        {
            masked = true;
            print("collided mask");
            //SteamVR_LoadLevel.Begin(sceneName);

        }

    }
}
