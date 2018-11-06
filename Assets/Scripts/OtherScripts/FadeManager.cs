using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour {
    
    public static FadeManager Instance{set;get;}
    
    public Image FadeImage;
    private bool isInTransition;
    private float transition;
    private bool isShowing;
    private float duration;
    private GameObject LiftGet;
    private bool LiftGot;
    private bool LiftStart;
    
    void Start()
    {
        LiftGet = GameObject.FindGameObjectWithTag("FadeTrigger");
        Debug.Log(LiftGet.GetComponent<FadeTrigger>().fadeNow);
        LiftGot = LiftGet.GetComponent<FadeTrigger>().fadeNow;
        LiftStart = false;
        Debug.Log(LiftGot);
    }
    
    private void Awake()
    {
        Instance = this;
    }

    public void Fade(bool showing, float duration)
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;
    }
    

    private void Update()
    {
    
    LiftGot = LiftGet.GetComponent<FadeTrigger>().fadeNow;
//        if (Input.GetKeyDown("space"))
//        {
//            Fade(true, 1.25f);
//        }

Debug.Log(LiftGot);
Debug.Log(LiftStart);

        if (LiftGot == true && LiftStart == false)
        {

                Fade(true, 1.25f);
                LiftStart = true;
        }


        if (Input.GetKeyDown("space"))
        {
            Fade(false, 3.00f);
        }
        

        
        if(!isInTransition)
            return;
            
            transition += (isShowing) ? Time.deltaTime * (1/duration) : -Time.deltaTime * (1/duration);
            
            FadeImage.color = Color.Lerp(new Color (1,1,1,0), Color.black, transition);
            
            if(transition > 1 || transition < 0)
            isInTransition = false;
    }
}
