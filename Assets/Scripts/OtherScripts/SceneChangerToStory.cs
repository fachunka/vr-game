using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerToStory : MonoBehaviour {

    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "MainCamera")
            {
                SceneManager.LoadSceneAsync("Comic_Test_Matias", LoadSceneMode.Single);
                Debug.Log("Change scene");
            }

        }


}
