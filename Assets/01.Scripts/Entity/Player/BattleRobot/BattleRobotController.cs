using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotController : MonoBehaviour
{
    [SerializeField] private BattleRobot _battleRobot;
    [SerializeField] private BattleRobotDrone _battleRobotDrone;

    [SerializeField] private LayerMask _targetLayer;

    private bool _canSelectWeapon = true;
    private WeaponFactory _weaponFactory;

    private void Awake()
    {
        _weaponFactory = GetComponent<WeaponFactory>();
    }

    private void Start()
    {
        _battleRobotDrone.SetTarget(_battleRobot.DroneTarget);

        _weaponFactory.SetWeapon(_battleRobotDrone.transform, Vector3.zero);

        foreach (WeaponSelect weaponSelect in PlanetManager.WeaponRegister.WeaponSelectList)
        {
            Weapon weapon = _weaponFactory.CreateWeapon(weaponSelect);
            weapon.SetWeapon(weaponSelect.BulletPrefab, _targetLayer);

            _battleRobotDrone.SubscribeWeapon(weaponSelect.WeaponType, weapon);

            weapon.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        SignalHub.OnChangedWeaponEvent    += SelectWeapon;
        SignalHub.OnChangedRobotFormEvent += ChangedRobotForm;
    }

    private void OnDisable()
    {
        SignalHub.OnChangedWeaponEvent    -= SelectWeapon;
        SignalHub.OnChangedRobotFormEvent -= ChangedRobotForm;
    }

    private void SelectWeapon(WeaponSelect weaponSelect)
    {
        if(_canSelectWeapon)
            _battleRobotDrone.SelectWeapon(weaponSelect.WeaponType);
    }

    private void ChangedRobotForm(bool isRobotForm)
    {
        _canSelectWeapon = isRobotForm;

        if (!isRobotForm)
        {
            _battleRobotDrone.HideWeapon();
        }
    }
}