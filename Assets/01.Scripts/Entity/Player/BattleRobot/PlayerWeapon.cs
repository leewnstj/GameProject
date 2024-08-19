using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponSelect
{
    public WeaponType WeaponType;
    public Bullet BulletPrefab;
    public GameObject Weapon;
}

public class PlayerWeapon : MonoBehaviour, IEventPublisher
{
    [SerializeField] private List<WeaponSelect> _weaponSelectList = new();
    [SerializeField] private LayerMask _targetLayer;

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
        WeaponSelect weaponSelect = _weaponSelectList.Find(weapon => weapon.WeaponType == type);
    }
}