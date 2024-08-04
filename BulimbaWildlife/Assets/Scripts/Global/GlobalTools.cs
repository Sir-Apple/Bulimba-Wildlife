using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTools : Singleton<GlobalTools>
{
    //Look at target
    public void LookAtObject(Transform targetTransform, Transform myTransform, float lookAtRotateSpeed)
    {
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
                       Quaternion.LookRotation(
                       new Vector3(targetTransform.position.x, 0f, targetTransform.position.z) -
                       new Vector3(myTransform.position.x, 0f, myTransform.position.z))
                       , lookAtRotateSpeed);
    }

    public void LookAtObject(Vector3 targetPosition, Transform myTransform, float lookAtRotateSpeed)
    {
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
                       Quaternion.LookRotation(
                       new Vector3(targetPosition.x, 0f, targetPosition.z) -
                       new Vector3(myTransform.position.x, 0f, myTransform.position.z))
                       , lookAtRotateSpeed);
    }
}
