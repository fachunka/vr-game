using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructionController : MonoBehaviour
{

    //    public GameObject remains;

    [SerializeField]
    private GameObject remains;

    public GameObject gameObContainingScript;

    bool touchingScissors;
    float currentTime;

    // Use this for initialization
    void Start()
    {
        touchingScissors = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            Instantiate(remains, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        //if time has changed 3seconds, instantiate meatchunk
        if (touchingScissors == true)
        {
            if (Time.fixedTime - currentTime >= 1 && currentTime > 0)
            {
                print("breaking meat");
                Instantiate(remains, transform.position, transform.rotation);
                Destroy(gameObject);
                touchingScissors = false;
            }
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
                currentTime = Time.fixedTime;
                touchingScissors = true;
            }
        }
    }
}
