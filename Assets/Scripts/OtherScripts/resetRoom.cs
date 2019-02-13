using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetRoom : MonoBehaviour {

	// void Start() {
	// 	PlayerPrefs.SetInt("Score", 20);
	// 	PlayerPrefs.DeleteAll();
	// }

	// void Update() {
	// 	Debug.Log(PlayerPrefs.GetInt("Score").ToString());
	// }


	void OnTriggerEnter(Collider other)
	{
			if (other.gameObject.tag == "GameController")
			{
 			PlayerPrefs.DeleteAll();
			}

	}
}
