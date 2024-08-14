using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolableMono
{
    private LayerMask _targetLayer;
    private Rigidbody _rigidCompo;

    private void Awake()
    {
        _rigidCompo = GetComponent<Rigidbody>();
    }

    public void Setting(LayerMask target)
    {
        _targetLayer = target;
    }

    public void Fire(Vector3 direction)
    {
        _rigidCompo.AddForce(direction, ForceMode.Impulse);
    }
}