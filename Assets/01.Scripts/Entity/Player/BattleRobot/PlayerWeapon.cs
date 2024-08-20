using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class WeaponSelect
{
    public WeaponType WeaponType;
    public Bullet BulletPrefab;
    public Weapon Weapon;
}

public class PlayerWeapon : MonoBehaviour, IEventPublisher
{
    [SerializeField] private List<WeaponSelect> _weaponSelectList = new();
    [SerializeField] private LayerMask _targetLayer;

    public WeaponType CurrentWeapon;

    public void SubscribeEvent()
    {
        PlayerHub.OnChangedWeaponEvent += SelectWeapon;
    }

    public void UnSubscribeEvent()
    {
        PlayerHub.OnChangedWeaponEvent -= SelectWeapon;
    }

    private void SelectWeapon(WeaponType type)
    {
        CurrentWeapon = type;
        WeaponSelect weaponSelect = _weaponSelectList.Find(weapon => weapon.WeaponType == type);

        weaponSelect.Weapon.SetWeapon(weaponSelect.BulletPrefab, _targetLayer);
    }

    private void Update()
    {
        if(Mouse.current.leftButton.isPressed)
        {
            PlayerHub.OnLeftMouseEvent?.Invoke();
        }
    }
}