using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotController : MonoBehaviour
{
    [SerializeField] private BattleRobot _battleRobotPrefab;
    [SerializeField] private BattleRobotDrone _battleRobotDronePrefab;

    [SerializeField] private WeaponFactory _weaponFactory;

    [SerializeField] private LayerMask _targetLayer;

    private void Start()
    {
        _battleRobotDronePrefab.SetTarget(_battleRobotPrefab.DroneTarget);

        _weaponFactory.SetWeapon(_battleRobotDronePrefab.transform, Vector3.zero);

        foreach (WeaponSelect weaponSelect in PlanetManager.WeaponRegister.WeaponSelectList)
        {
            Weapon weapon = _weaponFactory.CreateWeapon(weaponSelect);
            weapon.SetWeapon(weaponSelect.BulletPrefab, _targetLayer);

            _battleRobotDronePrefab.SubscribeWeapon(weaponSelect.WeaponType, weapon);

            weapon.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        SignalHub.OnChangedWeaponEvent += CreateWeapon;
    }

    private void OnDisable()
    {
        SignalHub.OnChangedWeaponEvent -= CreateWeapon;
    }

    private void CreateWeapon(WeaponSelect weaponSelect)
    {
        _battleRobotDronePrefab.SelectWeapon(weaponSelect.WeaponType);
    }
}