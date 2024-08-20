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

public class SelectWeaponHandler : MonoBehaviour, IEventPublisher
{
    [SerializeField] private List<WeaponSelect> _weaponSelectList = new();
    [SerializeField] private LayerMask _targetLayer;

    public WeaponType CurrentWeapon;

    private void Start()
    {
        SelectWeapon(WeaponType.Rifle);
    }

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
        if (CurrentWeapon == type) return;

        CurrentWeapon = type;
        WeaponSelect weaponSelect = _weaponSelectList.Find(weapon => weapon.WeaponType == type);

        PlayerHub.OnSelectWeaponEvent?.Invoke(weaponSelect);
    }

    private void Update()
    {
        if(Mouse.current.leftButton.isPressed)
        {
            PlayerHub.OnLeftMouseEvent?.Invoke();
        }
    }
}