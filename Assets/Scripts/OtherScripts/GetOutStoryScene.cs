using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOutStoryScene : MonoBehaviour {

	// Use this for initialization
	public GameObject gameObContainingScript;
	public GameObject gameObContainingScript2;
	public string sceneName;
    private float fadeDuration = 1f;
	
	// Update is called once per frame
	void Update () {

 		ControllerGrabObject  ControllerGrabObjectScript = gameObContainingScript.GetComponent<ControllerGrabObject>();
		ControllerGrabObject  ControllerGrabObjectScript2 = gameObContainingScript2.GetComponent<ControllerGrabObject>();
	if (ControllerGrabObjectScript.GetOutStoryScene == true  || ControllerGrabObjectScript2.GetOutStoryScene == true)
        {
		//	print("getout");
			 FadeToBlack();
            SteamVR_LoadLevel.Begin(sceneName);
		}
		
	}

	    private void FadeToBlack()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, fadeDuration);

    }

}
