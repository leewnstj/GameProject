#region Input

public delegate void ChangeWeaponEvent(WeaponSelect weaponSelect);

#endregion

public static class PlayerHub
{
    public static ChangeWeaponEvent OnChangedWeaponEvent;
}