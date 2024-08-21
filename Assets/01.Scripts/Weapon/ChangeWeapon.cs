public class ChangeWeapon : IEventPublisher
{
    private float _coolTime = 0f;
    private bool _canChangingWeapon = true;

    public void SetInit(float coolTime)
    {
        _coolTime = coolTime;
    }

    public void SubscribeEvent()
    {
        InputManager.OnNumberInputEvent += WeaponChange;
    }

    public void UnSubscribeEvent()
    {
        InputManager.OnNumberInputEvent -= WeaponChange;
    }

    public void WeaponChange(int inputNumber)
    {
        if (!_canChangingWeapon) return;

        _canChangingWeapon = false;

        WeaponSelect weaponSelect = PlanetManager.WeaponRegister.WeaponSelectList[inputNumber];
        PlayerHub.OnChangedWeaponEvent?.Invoke(weaponSelect);

        CoroutineUtil.CallWaitForSeconds(_coolTime, () => _canChangingWeapon = true);
    }
}