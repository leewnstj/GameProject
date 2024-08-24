using System.Collections.Generic;

public class ChangeWeapon
{
    private List<WeaponSelect> _weaponSelectList = new();

    private float _coolTime = 0f;
    private bool _canChangingWeapon = true;

    public ChangeWeapon(List<WeaponSelect> weaponSelectList, float coolTime)
    {
        _weaponSelectList = weaponSelectList;

        _coolTime = coolTime;
    }

    public void WeaponChange(int inputNumber)
    {
        if (!_canChangingWeapon) return;

        WeaponSelect weaponSelect = _weaponSelectList[inputNumber];

        _canChangingWeapon = false;

        SignalHub.OnChangedWeaponEvent?.Invoke(weaponSelect);

        CoroutineUtil.CallWaitForSeconds(_coolTime, () => _canChangingWeapon = true);
    }
}