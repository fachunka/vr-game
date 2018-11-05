using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButtonFoodDispenser : MonoBehaviour {

    [SerializeField]
    private GameObject meat;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		//limit the button movement
        //collide = push with limitation
	}

    //when the player touches button create lime
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Button")
        {
            Instantiate(meat, transform.position, transform.rotation);

            //create cute object called lime
            //Debug.Log("button pushed");
            //GameObject Lime = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //Lime.AddComponent<Rigidbody>();
            //Lime.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            //Lime.transform.position = new Vector3(-2, 2, 0.2f);
        }
    }
}
