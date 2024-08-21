public delegate void ChangeWeaponEvent(WeaponSelect weaponSelect);

public static class SignalHub
{
    public static ChangeWeaponEvent OnChangedWeaponEvent;
}