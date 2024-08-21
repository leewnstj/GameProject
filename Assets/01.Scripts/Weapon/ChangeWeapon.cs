using System.Collections.Generic;

public class ChangeWeapon
{
    private List<WeaponSelect> _weaponSelectList = new();

    private float _coolTime = 0f;
    private bool _canChangingWeapon = true;

    public void SetInit(List<WeaponSelect> weaponSelectList, float coolTime)
    {
        _weaponSelectList = weaponSelectList;

        _coolTime = coolTime;
    }

    public void WeaponChange(int inputNumber)
    {
        if (!_canChangingWeapon) return;

        _canChangingWeapon = false;

        WeaponSelect weaponSelect = _weaponSelectList[inputNumber];
        SignalHub.OnChangedWeaponEvent?.Invoke(weaponSelect);

        CoroutineUtil.CallWaitForSeconds(_coolTime, () => _canChangingWeapon = true);
    }
}