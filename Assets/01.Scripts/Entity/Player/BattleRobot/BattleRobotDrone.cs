using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BattleRobotDrone : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _rotationSpeed = 2.0f; // 회전 속도

    private Transform _endPoint;
    public void SetTarget(Transform target)
    {
        _endPoint = target;
    }

    private void FixedUpdate()
    {
        // 위치 이동
        transform.position = Vector3.MoveTowards(transform.position, _endPoint.position, _moveSpeed * Time.fixedDeltaTime);

        // 회전
        transform.rotation = Quaternion.Slerp(transform.rotation, _endPoint.rotation, _rotationSpeed * Time.fixedDeltaTime);
    }
}