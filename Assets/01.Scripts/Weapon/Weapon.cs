using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponDataSO _weaponData;

    [SerializeField] protected Transform _firePos;

    private Bullet _bulletPrefab;
    private LayerMask _targetLayer;

    protected int _maxBullet = 0;
    protected bool _delayShoot = false;

    protected Vector3 _fireDirection => new Vector3(_firePos.forward.x, 0, _firePos.forward.z);

    private void Start()
    {
        _maxBullet = _weaponData.AmmoCapacity;
    }

    public void SetWeapon(Bullet bullet, LayerMask target)
    {
        _bulletPrefab = bullet;
        _targetLayer  = target;
    }

    protected void Shoot()
    {
        if (_maxBullet > 0 && !_delayShoot)
        {
            if(_maxBullet > _weaponData.BulletCount)
            {
                for(int i = 0; i < _weaponData.BulletCount; i++)
                {
                    UseBullet(_weaponData.BulletCount);
                    ShootBullet();
                }
            }
            else
            {
                _delayShoot = true;
                return;
            }

            StartCoroutine(ShootDelayCoroutine());
        }
    }

    private IEnumerator ShootDelayCoroutine()
    {
        _delayShoot = true;
        yield return new WaitForSeconds(_weaponData.WeaponDelay);
        _delayShoot = false;
    }

    public void ShootBullet()
    {
        Bullet bullet = PoolManager.Instance.Pop(_bulletPrefab.name) as Bullet;

        float spread = Random.Range(-_weaponData.SpreadAngle, _weaponData.SpreadAngle);

        Quaternion bulletSpreadRot = Quaternion.Euler(spread, _firePos.rotation.y, spread) * _firePos.rotation;

        bullet.transform.position = _firePos.position;
        bullet.transform.rotation = bulletSpreadRot;    

        bullet.Setting(_targetLayer);
        bullet.Fire(bullet.transform.forward * _weaponData.BulletSpeed);
    }

    protected void UseBullet(int count) => _maxBullet -= count;
}