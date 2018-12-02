using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskSceneChange : MonoBehaviour {

    private bool masked;
    public string sceneName;
    private float fadeDuration = 1f;
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
        //Debug.Log('3');

    }

    private void FadeFromWhite()
    {
        //set start color
        SteamVR_Fade.Start(Color.white, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.clear, fadeDuration);
        //Debug.Log('4');

    }

    private void FadeFromBlack()
    {
        //set start color
        SteamVR_Fade.Start(Color.black, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.clear, fadeDuration);
        //Debug.Log('4');

    }

    private void FadeToBlack()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, fadeDuration);
        //Debug.Log('3');

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
            // FadeToWhite();
            // Invoke("FadeFromWhite", fadeDuration);

            //Debug.Log('1');
            //SteamVR_LoadLevel.Begin(sceneName);
            FadeToBlack();

            //Debug.Log('2');
            SteamVR_LoadLevel.Begin(sceneName);


            masked = false;
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
