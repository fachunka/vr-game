﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutleryBox : MonoBehaviour {

	public bool keyed = false;
	// public GameObject toDestroy;
	public GameObject toReplace;
	private Vector3 slightlyOpenPos;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
				// print(this.transform.parent.transform.position);
				// print(this.transform.parent.name);

				if (keyed == true)
				{
						slightlyOpenPos = this.transform.parent.transform.position;

						Destroy(this.transform.parent.gameObject);

						Instantiate(toReplace, slightlyOpenPos, Quaternion.Euler(new Vector3(0, 180, 0)));
						print("keyed");
				}

	}

	void OnTriggerEnter(Collider other)
	{
			if (other.gameObject.tag == "Key")
			{
					keyed = true;
					print("collided key");
			}

	}
}
