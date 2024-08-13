using UnityEngine;

public class RobotMouse
{
    private Transform _ownerTrm;

    public RobotMouse(Transform owner)
    {
        _ownerTrm = owner;
    }

    public void RotateTowardsMouse(float rotateSpeed)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.y - _ownerTrm.position.y; 
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 direction = (mouseWorldPos - _ownerTrm.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        _ownerTrm.rotation = Quaternion.Slerp(_ownerTrm.rotation, lookRotation, Time.deltaTime * rotateSpeed);
    }
}