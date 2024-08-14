using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotAttack : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _firePos;
    [SerializeField] private LayerMask _targetLayer;

    public void ShootBullet()
    {

    }

    private void SpawnBullet()
    {
        Bullet bullet = Instantiate(_bulletPrefab, _firePos.position, _firePos.rotation);
        Vector3 dir = new Vector3(_firePos.forward.x, 0, _firePos.forward.z) * 10f;

        bullet.Setting(_targetLayer);
        bullet.Fire(dir);
    }
}