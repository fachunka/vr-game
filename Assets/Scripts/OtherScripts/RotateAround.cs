using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

    public GameObject axis;
    public float radiusSpeed;
    public float radius;
    public float rotationSpeed;
    private Vector3 desiredPosition;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        OrbitAround();	
	}

    void OrbitAround()
    {
        transform.RotateAround(axis.transform.position, Vector3.down, rotationSpeed * Time.deltaTime);
        desiredPosition = (transform.position - axis.transform.position).normalized * radius + axis.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    }

    //when grabbed with hand(this time scissors), stop rotation and enable the UI screen
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Scissors")
        {
            print("rotating ball collided with scissors");
        }
    }
    
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Scissors")
        {
        }
    }
}
