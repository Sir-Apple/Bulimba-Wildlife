using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerCharacter;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void Start()
    {
        //playerCharacter = CharactorManager.Instance.GetCurrentCharactorTransform();
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = playerCharacter.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
