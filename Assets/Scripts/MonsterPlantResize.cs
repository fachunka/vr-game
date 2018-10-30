using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPlantResize : MonoBehaviour {
    bool monsterFeeded = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        //if object collides with chunk of meat
        if (monsterFeeded == false)
        {
            if (col.tag == "MeatChunk")
            {
                Debug.Log("Monster feeded");
                transform.localScale = new Vector3(0.15f, 0.3f, 0.15f);
                monsterFeeded = true;
            }
        }
    }
}
