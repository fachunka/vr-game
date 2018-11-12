using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructionController : MonoBehaviour
{

    //    public GameObject remains;

    [SerializeField]
    private GameObject remains;

    public GameObject gameObContainingScript;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            Instantiate(remains, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        ChangeTexture ChangeTextureScript = gameObContainingScript.GetComponent<ChangeTexture>();
        
        //when scissors collide with "cooked" meat, it breaks down into three pieces
        if (col.gameObject.tag == "Scissors")
        {
            if (ChangeTextureScript.meatTextureChanged == true)
            {
                print("breaking meat");
                Instantiate(remains, transform.position, transform.rotation);
                Destroy(gameObject);
                //gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
        }
    }
}
