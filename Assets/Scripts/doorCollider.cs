using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorCollider : MonoBehaviour {

    void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.name == "Door")
        {
            SceneManager.LoadScene("SampleScene2");
        }
    }
}
