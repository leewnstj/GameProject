public delegate void ChangeWeaponEvent(WeaponSelect weaponSelect);
public delegate void ChangeRobotForm(bool robotForm);

public static class SignalHub
{
    public static ChangeWeaponEvent OnChangedWeaponEvent;
    public static ChangeRobotForm   OnChangedRobotFormEvent;
}