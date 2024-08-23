using UnityEngine;

public class WeaponFactory : EntityFactory<Weapon>
{
    private Transform _parent;
    private Vector3 _spawnPosition;

    public void SetWeapon(Transform parent, Vector3 spawnPosition)
    {
        _parent = parent;
        _spawnPosition = spawnPosition;
    }

    public Weapon CreateWeapon(WeaponSelect weaponSelect)
    {
        Weapon weapon = SpawnObject(weaponSelect.Weapon) as Weapon;

        weapon.transform.SetParent(_parent);
        weapon.transform.localPosition = _spawnPosition;

        return weapon;
    }

    protected override PoolableMono Create(Weapon type)
    {
        string originalString = type.ToString();
        string resultString = originalString.Substring(0, originalString.LastIndexOf(" "));

        Weapon spawnBuilding = PoolManager.Pop(resultString) as Weapon;

        return spawnBuilding;
    }
}