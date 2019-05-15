using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePos : MonoBehaviour {

    public bool liftMoving = true;

    void Update () {

        if (transform.position.y <= 1)
        {
            transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.0045f, transform.localPosition.z);
            liftMoving = true;
        }
        else if (transform.position.y >= 1)
        {
            liftMoving = false;
        }
    }
}
