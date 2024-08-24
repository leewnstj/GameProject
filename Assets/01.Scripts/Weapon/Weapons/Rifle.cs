public class Rifle : Weapon
{
    private void OnEnable()
    {
        InputManager.OnLeftMouseEvent += Shoot;
    }

    private void OnDisable()
    {
        InputManager.OnLeftMouseEvent -= Shoot;
    }

    protected override void ShootProcessing()
    {
        CreateBullet<Bullet>();

        SetBulletTransform(_firePos);
        BulletDirection<Bullet>(_bullet, _firePos);
        ShootBullet(_bullet.transform.forward * _weaponData.BulletSpeed);
    }
}