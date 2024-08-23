using System.Collections.Generic;
using UnityEngine;

public class BattleRobotDrone : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _rotationSpeed = 2.0f; // 회전 속도

    private Dictionary<WeaponType, Weapon> _weaponByType = new();

    private Weapon _currentWeapon;

    private Transform _endPoint;

    private bool _awayFromPlayer => Vector3.Distance(transform.position, _endPoint.position) > 2f;

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

    public void HideWeapon()
    {
        if (_currentWeapon != null)
        {
            Weapon beforeWeapon = _currentWeapon;

            beforeWeapon.Dissolve(1, 0.5f, () =>
            {
                beforeWeapon.gameObject.SetActive(false);
            });

            _currentWeapon = null;
        }
    }

    public void SelectWeapon(WeaponType type)
    {
        if(_weaponByType.TryGetValue(type, out Weapon weapon))
        {
            if (_currentWeapon != null)
            {
                Weapon beforeWeapon = _currentWeapon;

                beforeWeapon.Dissolve(1, 0.5f, () =>
                {
                    beforeWeapon.gameObject.SetActive(false);
                });
            }

            _currentWeapon = weapon;
            _currentWeapon.Dissolve(0, 0.5f);
            _currentWeapon.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        // 위치 이동
        if (_awayFromPlayer)
            _moveSpeed = 12f;
        else
            _moveSpeed = 5f;

        transform.position = Vector3.MoveTowards(transform.position, _endPoint.position, _moveSpeed * Time.fixedDeltaTime);

        // 회전
        transform.rotation = Quaternion.Slerp(transform.rotation, _endPoint.rotation, _rotationSpeed * Time.fixedDeltaTime);
    }
}