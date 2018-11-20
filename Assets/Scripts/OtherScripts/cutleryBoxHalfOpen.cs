using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutleryBoxHalfOpen : MonoBehaviour {

	private bool limed = false;
	// public GameObject toDestroy;
	public GameObject toReplace;
	public GameObject scissorsBox;
	private Vector3 slightlyOpenPos = new Vector3(0.85f, 1.68f, 1);
	private Vector3 scissorsPos = new Vector3(0.85f, 1.69f, 1);
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
				// print(this.transform.parent.transform.position);
				// print(this.transform.parent.name);

				if (limed == true)
				{

						slightlyOpenPos = this.transform.parent.transform.position;

						Destroy(this.transform.parent.gameObject);

						Instantiate(toReplace, slightlyOpenPos, Quaternion.identity);
						Instantiate(scissorsBox, scissorsPos, Quaternion.identity);
						print("limed");

				}



	}

	void OnTriggerEnter(Collider other)
	{

			if (other.gameObject.tag == "Lime")
			{
					limed = true;
					print("collided lime");

			}
	}
}
