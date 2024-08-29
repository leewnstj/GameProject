using ComponentPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : EntityRotation, IEntityComponent
{
    private float _rotateSpeed;

    public void Init(Entity component)
    {
        SetOwnerTransform(component.transform);
        _rotateSpeed = component.RobotSO.RotateSpeed;
    }

    private void FixedUpdate()
    {
        RotateTowardsMouse();
    }

    public void RotateTowardsMouse()
    {
        if (!_canRotation) return;

        Vector3 mousePos = Input.mousePosition;
        Ray cameraRay = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(cameraRay, out hit, Camera.main.farClipPlane))
        {
            _direction = hit.point - _ownerTrm.position;
            _direction.y = 0;

            Rotation(_rotateSpeed);
        }
    }
}