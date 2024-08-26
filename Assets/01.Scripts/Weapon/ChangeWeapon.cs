using ComponentPattern;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour, IPlayerComponent
{
    private List<WeaponSelect> _weaponSelectList => PlanetManager.WeaponRegister.WeaponSelectList;

    private float _coolTime = 0f;
    private bool _canChangingWeapon = true;

    public void Init(Player component)
    {
        _coolTime = component.RobotSO.ChangWeaponCoolTime;
    }

    private void OnEnable()
    {
        InputManager.OnNumberInputEvent += WeaponChange;
    }

    private void OnDisable()
    {
        InputManager.OnNumberInputEvent -= WeaponChange;
    }

    private void WeaponChange(int inputNumber)
    {
        if (!_canChangingWeapon) return;

        WeaponSelect weaponSelect = _weaponSelectList[inputNumber];

        _canChangingWeapon = false;

        SignalHub.OnChangedWeaponEvent?.Invoke(weaponSelect);

        CoroutineUtil.CallWaitForSeconds(_coolTime, () => _canChangingWeapon = true);
    }
}