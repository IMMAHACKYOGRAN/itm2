using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow: MonoBehaviour
{
    public Transform sub;

    void Start() {
        transform.position = sub.position;
        transform.rotation = sub.rotation;
    }

    void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, sub.position, 0.75f);
        transform.rotation = Quaternion.Slerp(transform.rotation, sub.rotation, 0.5f);
    }
}
