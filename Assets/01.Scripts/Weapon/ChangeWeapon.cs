using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : IEventPublisher
{
    public List<WeaponType> _weaponTypes = new();
    private WeaponType _currentWeapon = WeaponType.None;
    private float _coolTime = 3f;

    private bool _canChangingWeapon = true;

    public void SetInit(List<WeaponType> weaponTypes, float coolTime)
    {
        _weaponTypes = weaponTypes;

        _coolTime = coolTime;
    }

    public void SubscribeEvent()
    {
        PlayerHub.OnChangedWeaponInputEvent += WeaponChange;
    }

    public void UnSubscribeEvent()
    {
        PlayerHub.OnChangedWeaponInputEvent -= WeaponChange;
    }

    public void WeaponChange(int inputNumber)
    {
        if (!_canChangingWeapon) return;
        _canChangingWeapon = false;

        _currentWeapon = _weaponTypes[inputNumber];
        PlayerHub.OnChangedWeaponEvent?.Invoke(_currentWeapon);

        CoroutineUtil.CallWaitForSeconds(_coolTime, () => _canChangingWeapon = true);
    }
}