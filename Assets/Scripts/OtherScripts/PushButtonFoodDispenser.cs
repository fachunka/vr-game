using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButtonFoodDispenser : MonoBehaviour
{
    [SerializeField]
    private GameObject meat;

    Vector3 positionMeat;

    // Use this for initialization
    void Start()
    {
        positionMeat = new Vector3(0.1f, 0, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        //limit the button movement
        //collide = push with limitation
    }

    //when the player touches button create lime
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Button")
        {
            //create meat prefab
            Instantiate(meat, transform.position + positionMeat, Quaternion.identity);

            //create object called lime
            //Debug.Log("button pushed");
            //GameObject Lime = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //Lime.AddComponent<Rigidbody>();
            //Lime.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            //Lime.transform.position = new Vector3(-2, 2, 0.2f);

            //new Vector3(-2, 2, 0.2f)
        }
    }
}
