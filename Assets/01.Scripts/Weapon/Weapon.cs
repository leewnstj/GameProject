using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Weapon : PoolableMono
{
    [Header("Weapon")]

    [SerializeField] protected WeaponDataSO _weaponData;
    [SerializeField] protected Transform _firePos;

    private Bullet _bulletPrefab;
    private LayerMask _targetLayer;

    protected int _maxBullet = 0;
    protected bool _delayShoot = false;

    protected Vector3 _fireDirection => new Vector3(_firePos.forward.x, 0, _firePos.forward.z);

    private MeshRenderer[] _meshRenderers;

    private void Awake()
    {
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    private void Start()
    {
        _maxBullet = _weaponData.AmmoCapacity;
    }

    public void Dissolve(int value, float duration, Action onEndDissolveAction = null)
    {
        foreach (var meshRenderer in _meshRenderers)
        {
            meshRenderer.material.DOFloat(value, "_DissolveAmount", duration);
        }
    }

    public void SetWeapon(Bullet bullet, LayerMask target)
    {
        _bulletPrefab = bullet;
        _targetLayer  = target;
    }

    protected virtual void Shoot()
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

    protected IEnumerator ShootDelayCoroutine()
    {
        _delayShoot = true;
        yield return new WaitForSeconds(_weaponData.WeaponDelay);
        _delayShoot = false;
    }

    public void ShootBullet()
    {
        Bullet bullet = PoolManager.Pop(_bulletPrefab.name) as Bullet;

        float spread = Random.Range(-_weaponData.SpreadAngle, _weaponData.SpreadAngle);

        Quaternion bulletSpreadRot = Quaternion.Euler(spread, _firePos.rotation.y, spread) * _firePos.rotation;

        bullet.transform.position = _firePos.position;
        bullet.transform.rotation = bulletSpreadRot;    

        bullet.Setting(_targetLayer);
        bullet.Fire(bullet.transform.forward * _weaponData.BulletSpeed);
    }

    protected void UseBullet(int count) => _maxBullet -= count;
}