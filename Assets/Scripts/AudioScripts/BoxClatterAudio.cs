using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxClatterAudio : MonoBehaviour {

    public AudioClip[] boxClatterClips;
    private AudioSource audioSource;
    private bool clatterEnable = false;     

    void Awake()
        {
            StartCoroutine(EnableClatter());
        }

    IEnumerator EnableClatter()
    {
        yield return(60);           // a small delay before enabling clatter sounds to let opening sound play
        clatterEnable = true;
        yield return(0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key" || other.gameObject.tag == "Lime" 
        || other.gameObject.tag == "GameController" || other.gameObject.tag == "MainCamera"
        || other.gameObject.tag == "Player")
        {
            // Don't play any sound
        }

        else
        {
            if (clatterEnable == true)
            {
            audioSource = gameObject.GetComponent<AudioSource>();
            int randClatter = Random.Range (0, boxClatterClips.Length);
            audioSource.clip = boxClatterClips[randClatter];
            audioSource.Play();
            }
        }
    }

}
