using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPlantResize : MonoBehaviour {
    bool monsterFeeded = false;
    bool meatChunkDeleted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        //if meatchunk collides, make it disappear
        if (monsterFeeded == true)
        {
            if (meatChunkDeleted == false)
            {
                Debug.Log("Monster feeded, deleting meat chunk");
                GameObject.Find("Meat Chunk").transform.localScale = new Vector3(0, 0, 0);
                meatChunkDeleted = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //if object collides with meat chunk, make it small
        if (monsterFeeded == false)
        {
            if (other.gameObject.tag == "MeatChunk")
            {
                Debug.Log("Monster feeded");
                transform.localScale = new Vector3(0.15f, 0.3f, 0.15f);
                monsterFeeded = true;
            }
        }
    }
}
