using UnityEngine;

public class RobotRotation
{
    private Transform _ownerTrm;

    private bool _canRotation;

    public RobotRotation(Transform owner)
    {
        _ownerTrm = owner;
    }

    public void SetRotation(bool value) => _canRotation = value;

    public void RotateTowardsMouse(float rotateSpeed)
    {
        if (!_canRotation) return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.y - _ownerTrm.position.y; 
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 direction = (mouseWorldPos - _ownerTrm.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        _ownerTrm.rotation = Quaternion.Slerp(_ownerTrm.rotation, lookRotation, Time.deltaTime * rotateSpeed);
    }
}