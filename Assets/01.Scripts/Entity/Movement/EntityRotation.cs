using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityRotation : MonoBehaviour
{
    protected Transform _ownerTrm;
    protected Vector3 _direction;
    protected bool _canRotation;

    protected void SetOwnerTransform(Transform ownerTrm)
    {
        _ownerTrm = ownerTrm;
    }

    public void SetRotation(bool value)
    {
        _canRotation = value;
    }

    protected void Rotation(float rotateSpeed)
    {
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(_direction.x, 0, _direction.z));
        _ownerTrm.rotation = Quaternion.Slerp(_ownerTrm.rotation, lookRotation, Time.deltaTime * rotateSpeed);
    }
}