using System.Collections.Generic;

public class ChangeWeapon
{
    private List<WeaponSelect> _weaponSelectList = new();

    private float _coolTime = 0f;
    private bool _canChangingWeapon = true;

    private WeaponType _currentWeapon = WeaponType.None;

    public void SetInit(List<WeaponSelect> weaponSelectList, float coolTime)
    {
        _weaponSelectList = weaponSelectList;

        _coolTime = coolTime;
    }

    public void WeaponChange(int inputNumber)
    {
        if (!_canChangingWeapon) return;

        WeaponSelect weaponSelect = _weaponSelectList[inputNumber];

        if (_currentWeapon == weaponSelect.WeaponType) return;

        _canChangingWeapon = false;
        _currentWeapon = weaponSelect.WeaponType;

        SignalHub.OnChangedWeaponEvent?.Invoke(weaponSelect);

        CoroutineUtil.CallWaitForSeconds(_coolTime, () => _canChangingWeapon = true);
    }
}