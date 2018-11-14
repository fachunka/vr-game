using UnityEngine;
using System.Collections;

public class animationTrigger : MonoBehaviour
{
    AudioSource audioSource;

	public float startAnimation1;
	public float startAnimation2;
	public float startAnimation3;
	public float startAnimation4;

	private bool animation1Running = false;
	private bool animation2Running = false;
	private bool animation3Running = false;
	private bool animation4Running = false;

	public GameObject animationObject1;
	public GameObject animationObject2;
	public GameObject animationObject3;
	public GameObject animationObject4;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
		
		animationObject1.SetActive(false);
		animationObject2.SetActive(false);
		animationObject3.SetActive(false);
		animationObject4.SetActive(false);
    }

    void Update()
    {

        if (audioSource.time >= startAnimation1 && audioSource.time < (startAnimation1 + 0.5) && animation1Running == false)
		{
		animationObject1.SetActive(true);
		Debug.Log("<color=green>Animation 1</color>");
		animation1Running = true;
		}

	    if (audioSource.time >= startAnimation2 && audioSource.time < (startAnimation2 + 0.5) && animation2Running == false)
		{
		animationObject2.SetActive(true);
		Debug.Log("<color=green>Animation 2</color>");
		animation2Running = true;
		}

		if (audioSource.time >= startAnimation3 && audioSource.time < (startAnimation3 + 0.5) && animation3Running == false)
		{
		animationObject3.SetActive(true);
		Debug.Log("<color=green>Animation 3</color>");
		animation3Running = true;
		}

	    if (audioSource.time >= startAnimation4 && audioSource.time < (startAnimation4 + 0.5) && animation4Running == false)
		{
		animationObject4.SetActive(true);
		Debug.Log("<color=green>Animation 4</color>");
		animation4Running = true;
		}
	}
 
}