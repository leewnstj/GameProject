using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BattleRobotDrone : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _rotationSpeed = 2.0f; // 회전 속도

    private Dictionary<WeaponType, Weapon> _weaponByType = new();
    private Weapon _currentWeapon;

    private Transform _endPoint;

    public void SetTarget(Transform target)
    {
        _endPoint = target;
    }

    public void SubscribeWeapon(WeaponType type, Weapon weapon)
    {
        if(!_weaponByType.ContainsKey(type))
        {
            _weaponByType.Add(type, weapon);
        }
    }

    public void SelectWeapon(WeaponType type)
    {
        if(_weaponByType.TryGetValue(type, out Weapon weapon))
        {
            _currentWeapon?.gameObject.SetActive(false);
            _currentWeapon = weapon;
            weapon.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        // 위치 이동
        transform.position = Vector3.MoveTowards(transform.position, _endPoint.position, _moveSpeed * Time.fixedDeltaTime);

        // 회전
        transform.rotation = Quaternion.Slerp(transform.rotation, _endPoint.rotation, _rotationSpeed * Time.fixedDeltaTime);
    }
}