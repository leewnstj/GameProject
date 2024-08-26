using ComponentPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : EntityRotation, IPlayerComponent
{
    private float _rotateSpeed;

    public void Init(Player component)
    {
        SetOwnerTransform(component.transform);
        _rotateSpeed = component.RobotSO.RotateSpeed;
    }

    private void Update()
    {
        RotateTowardsMouse();
    }

    public void RotateTowardsMouse()
    {
        if (!_canRotation) return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.y - _ownerTrm.position.y;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        _direction = (mouseWorldPos - _ownerTrm.position).normalized;

        Rotation(_rotateSpeed);
    }
}
