using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponSelect
{
    public WeaponType WeaponType;
    public Bullet BulletPrefab;
    public Weapon Weapon;
}

[CreateAssetMenu(menuName = "SO/Register/Weapon")]
public class WeaponRegisterSO : ScriptableObject
{
    [SerializeField] private List<WeaponSelect> _weaponList = new();
    public List<WeaponSelect> WeaponSelectList => _weaponList;

    public WeaponSelect FindWeaponByType(WeaponType type)
    {
        return _weaponList.Find(weapon => weapon.WeaponType == type);
    }

    public List<WeaponType> TypesOfRegisterWeapon()
    {
        List<WeaponType> weaponTypes = new List<WeaponType>();

        for(int i = 0; i < _weaponList.Count; i++)
        {
            weaponTypes.Add(_weaponList[i].WeaponType);
        }

        return weaponTypes;
    }
}