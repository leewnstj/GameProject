using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotDrone : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _moveSpeed = 5.0f;
    [SerializeField] private float _rotationSpeed = 2.0f; // 회전 속도
    [SerializeField] private LayerMask _targetLayer;

    private void OnEnable()
    {
        PlayerHub.OnSelectWeaponEvent += CreateWeapon;
    }

    private void OnDisable()
    {
        PlayerHub.OnSelectWeaponEvent -= CreateWeapon;
    }

    private void FixedUpdate()
    {
        // 위치 이동
        transform.position = Vector3.MoveTowards(transform.position, _endPoint.position, _moveSpeed * Time.deltaTime);

        // 회전
        transform.rotation = Quaternion.Slerp(transform.rotation, _endPoint.rotation, _rotationSpeed * Time.deltaTime);
    }

    private void CreateWeapon(WeaponSelect weaponSelect)
    {
        Weapon weapon = Instantiate(weaponSelect.Weapon, transform);
        weapon.SetWeapon(weaponSelect.BulletPrefab, _targetLayer);
    }
}