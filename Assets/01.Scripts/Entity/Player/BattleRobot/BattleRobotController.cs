using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotController : MonoBehaviour
{
    [SerializeField] private BattleRobot _battleRobotPrefab;
    [SerializeField] private BattleRobotDrone _battleRobotDronePrefab;

    private WeaponFactory _weaponFactory;

    [SerializeField] private LayerMask _targetLayer;

    private void Awake()
    {
        _weaponFactory = GetComponent<WeaponFactory>();
    }

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
        SignalHub.OnChangedWeaponEvent += SelectWeapon;
    }

    private void OnDisable()
    {
        SignalHub.OnChangedWeaponEvent -= SelectWeapon;
    }

    private void SelectWeapon(WeaponSelect weaponSelect)
    {
        _battleRobotDronePrefab.SelectWeapon(weaponSelect.WeaponType);
    }
}