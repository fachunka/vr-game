using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    void Awake()
    {

        //this.gameObject.transform.position = new Vector3(0f, 2f, 0f);

        //GameObject[] objs = GameObject.FindGameObjectsWithTag("Ugali");

        //if (objs.Length > 1)
        //{
        //    Destroy(this.gameObject);
        //}

        DontDestroyOnLoad(this.gameObject);
    }

}
