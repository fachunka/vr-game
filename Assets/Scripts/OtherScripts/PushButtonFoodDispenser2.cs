using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButtonFoodDispenser2 : MonoBehaviour {

    public GameObject lime;
    public GameObject cornMeal;
    public GameObject mirandaLeaf;
    public GameObject banana;

    public float status;

    Vector3 positionAdjust;

    // Use this for initialization
    void Start()
    {
        positionAdjust = new Vector3(0.1f, 0, 0.3f);

        status = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //when the player touches button create lime
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ButtonVeg")
        {
            if (status % 4 == 0)
            {
                //create pork prefab
                Instantiate(lime, transform.position + positionAdjust, Quaternion.identity);
            }

            else if (status % 4 == 1)
            {
                Instantiate(cornMeal, transform.position + positionAdjust, Quaternion.identity);
            }

            else if (status % 4 == 2)
            {
                Instantiate(mirandaLeaf, transform.position + positionAdjust, Quaternion.identity);
            }

            else if (status % 4 == 3)
            {
                Instantiate(banana, transform.position + positionAdjust, Quaternion.identity);
            }

        }

        if (other.gameObject.tag == "ButtonCategoryVeg")
        {
            status += 1;
        }

    }
}
