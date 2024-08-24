using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

//WeaponFactory에서 생성이 된다.
//생성이될 떄 Weapon의 고유 Bullet과 Target이 지정된다.

public abstract partial class Weapon : PoolableMono
{
    [Header("Weapon")]
    [SerializeField] protected WeaponDataSO _weaponData;
    [SerializeField] protected Transform _firePos;

    private Bullet _bulletPrefab;
    protected LayerMask _targetLayer;

    protected int _maxBullet = 0;
    protected bool _delayShoot = false;

    protected Bullet _bullet;

    protected bool _canShoot => _maxBullet > 0 && !_delayShoot;
    protected Vector3 _fireDirection => new Vector3(_firePos.forward.x, 0, _firePos.forward.z);

    protected virtual void Start()
    {
        _maxBullet = _weaponData.AmmoCapacity;
    }

    /// <summary>
    /// Bullet과 Target 지정
    /// </summary>
    /// <param name="bullet">고유 탄약</param>
    /// <param name="target">타겟 레이어</param>
    public void SetWeapon<T>(T bullet, LayerMask target) where T : Bullet
    {
        _bulletPrefab = bullet;
        _targetLayer  = target;
    }


    protected virtual void Shoot()
    {
        if (!_canShoot) return;

        if(_maxBullet > _weaponData.BulletCount)
        {
            for(int i = 0; i < _weaponData.BulletCount; i++)
            {
                UseBullet(_weaponData.BulletCount);
                ShootProcessing();
            }
        }
        else
        {
            _delayShoot = true;
            return;
        }

        StartCoroutine(ShootDelayCoroutine());
    }

    /// <summary>
    /// 총알 발사 쿨타임
    /// </summary>
    /// <returns></returns>
    protected IEnumerator ShootDelayCoroutine()
    {
        _delayShoot = true;
        yield return new WaitForSeconds(_weaponData.WeaponDelay);
        _delayShoot = false;
    }

    protected abstract void ShootProcessing();

    protected virtual void CreateBullet<T>() where T : Bullet
    {
        _bullet = PoolManager.Pop(_bulletPrefab.name) as T;
    }

    protected virtual void SetBulletTransform(Transform transform)
    {
        _bullet.transform.position = transform.position;
    }

    protected virtual Quaternion BulletDirection<T>(T bullet, Transform transform) where T : Bullet
    {
        float spread = Random.Range(-_weaponData.SpreadAngle, _weaponData.SpreadAngle);

        Quaternion bulletSpreadRot = Quaternion.Euler(spread, transform.rotation.y, spread) * transform.rotation;

        bullet.transform.rotation = bulletSpreadRot;

        return bulletSpreadRot;
    }

    protected virtual void ShootBullet(Vector3 direction)
    {
        _bullet.Setting(_targetLayer);
        _bullet.Fire(direction);
    }

    protected void UseBullet(int count) => _maxBullet -= count;
}