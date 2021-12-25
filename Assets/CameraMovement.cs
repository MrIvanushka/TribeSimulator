using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _sensitivity;

    public void Move(Vector3 delta)
    {
        transform.position -= new Vector3(delta.x, 0, delta.y) * _sensitivity;
    }
}
