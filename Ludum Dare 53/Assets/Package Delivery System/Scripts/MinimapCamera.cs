using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool allowRotation = false;

    private Vector3 targetRot;

    private void LateUpdate()
    {
        transform.position = target.position + offset;

        if (allowRotation)
        {
            targetRot.x = transform.eulerAngles.x;
            targetRot.y = 0;
            targetRot.z = target.eulerAngles.y;
            transform.eulerAngles = targetRot;
        }
    }
}
