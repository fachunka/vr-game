using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneAudioManager : MonoBehaviour {

public float waitBeforeHelperVoice;

    public AudioSource helperAudioSource;
    public AudioClip helperAudioClip1;
    public AudioClip helperAudioClip2;
    public AudioClip helperAudioClip3;

	private GameObject elevatorAudio1;
	private GameObject elevatorAudio2;
	private AudioSource elevatorSource1;
	private AudioSource elevatorSource2;

	public AudioClip elevatorStopClip1;
	public AudioClip elevatorStopClip2;
	
	private bool clip1Played = false;

	void Start ()
	{
		StartCoroutine(playHelper());

		elevatorAudio1 = GameObject.Find("ElevatorAudio1"); 
		elevatorAudio2 = GameObject.Find("ElevatorAudio2"); 

		elevatorSource1 = elevatorAudio1.GetComponent<AudioSource>();
		elevatorSource2 = elevatorAudio2.GetComponent<AudioSource>();

		elevatorSource1.Play();
		elevatorSource2.Play();
	}
	

    IEnumerator playHelper()
    {
        helperAudioSource.clip = helperAudioClip1;
        yield return new WaitForSeconds(waitBeforeHelperVoice);
        helperAudioSource.loop = false;
        helperAudioSource.Play();
        yield return new WaitForSeconds(0);
    }

	void Update ()
	{
		if (helperAudioSource.time >= helperAudioSource.clip.length && !clip1Played)
		{
			clip1Played = true;

			elevatorSource1.clip = elevatorStopClip1;
			elevatorSource2.clip = elevatorStopClip2;

			elevatorSource1.Play();
			elevatorSource2.Play();

			StartCoroutine(playHelper2());
		}

		if (Input.GetKeyDown(KeyCode.H))
        {
			StartCoroutine(playHelper3());
        }
	}

	IEnumerator playHelper2()
	{
		yield return new WaitForSeconds(2);
        helperAudioSource.clip = helperAudioClip2;
        helperAudioSource.loop = false;
        helperAudioSource.Play();
        yield return new WaitForSeconds(0);
	}

	IEnumerator playHelper3()
	{
		yield return new WaitForSeconds(0);
        helperAudioSource.clip = helperAudioClip3;
        helperAudioSource.loop = false;
        helperAudioSource.Play();
        yield return new WaitForSeconds(0);
	}

}
