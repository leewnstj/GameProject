using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoSingleton<PlanetManager>
{
    [SerializeField] private WeaponRegisterSO _weaponRegister;
    public static WeaponRegisterSO WeaponRegister => Instance._weaponRegister;
}