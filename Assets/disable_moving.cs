

using UnityEngine;
using UnityEngine.XR;

public class disable_moving : MonoBehaviour
{
    void Update()
    {
        Vector3 positionVec = -InputTracking.GetLocalPosition(XRNode.CenterEye);
        transform.position = new Vector3(positionVec.x, transform.localPosition.y, positionVec.z - 1f);
    }
}