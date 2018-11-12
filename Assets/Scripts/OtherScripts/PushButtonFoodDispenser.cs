using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButtonFoodDispenser : MonoBehaviour
{
    [SerializeField]
    private GameObject meat;
    public GameObject lime;

    public float status;

    Vector3 positionPork;

    // Use this for initialization
    void Start()
    {
        positionPork = new Vector3(0.1f, 0, 0.3f);
        
        status = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //when the player touches button create lime
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Button")
        {
            if (status % 2 == 0)
            {
                //create pork prefab
                Instantiate(meat, transform.position + positionPork, Quaternion.identity);
            }

            else
            {
                Instantiate(lime, transform.position + positionPork, Quaternion.identity);
            }
            //create object called lime
            //Debug.Log("button pushed");
            //GameObject Lime = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //Lime.AddComponent<Rigidbody>();
            //Lime.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            //Lime.transform.position = new Vector3(-2, 2, 0.2f);

            //new Vector3(-2, 2, 0.2f)
        }

        if (other.gameObject.tag == "ButtonCategory")
        {
            status += 1;
        }

    }
}
