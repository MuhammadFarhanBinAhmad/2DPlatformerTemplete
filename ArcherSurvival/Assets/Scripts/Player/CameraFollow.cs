using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smooth_Speed = 0.125f;

    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 des_Pos = target.position + offset;
        Vector3 smooth_Pos = Vector3.Lerp(transform.position, des_Pos, smooth_Speed);
        transform.position = smooth_Pos;
    }
}
