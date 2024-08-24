using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _growthRate;

    public void Rotation()
    {
        transform.Rotate(Vector3.up * _growthRate * _rotateSpeed * Time.deltaTime);
    }
}