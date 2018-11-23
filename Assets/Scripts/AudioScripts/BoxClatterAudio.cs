using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxClatterAudio : MonoBehaviour {

    public AudioClip[] boxClatterClips;
    private AudioSource audioSource;

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
                audioSource = gameObject.GetComponent<AudioSource>();
                int randClatter = Random.Range (0, boxClatterClips.Length);
                audioSource.clip = boxClatterClips[randClatter];
                audioSource.Play();
            }
        }


}
