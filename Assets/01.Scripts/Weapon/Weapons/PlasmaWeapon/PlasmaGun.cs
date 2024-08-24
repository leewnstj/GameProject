using System;
using UnityEngine;
using UnityEngine.Events;

public class PlasmaGun : Weapon
{
    [Header("PlasmaGun")]
    [SerializeField] private float _minDamage;
    [SerializeField] private float _chargeRate = 10f;

    [SerializeField] private float _maxBulletSize; // 최대 사이즈
    [SerializeField] private float _growthRate = 1f; // 성장 속도


    public UnityEvent OnStartChargingEvent  = new();
    public UnityEvent OnUpdateChargingEvent = new();
    public UnityEvent OnEndChargingEvent    = new();

    private PlasmaBullet _currentPlasmaBullet;
    private float _currentDamage;

    private void OnEnable()
    {
        InputManager.OnLeftMouseDownEvent += StartCharging;
        InputManager.OnLeftMouseEvent     += UpdateCharging;
        InputManager.OnLeftMouseUpEvent   += StopCharging;
    }

    private void OnDisable()
    {
        InputManager.OnLeftMouseDownEvent -= StartCharging;
        InputManager.OnLeftMouseEvent     -= UpdateCharging;
        InputManager.OnLeftMouseUpEvent   -= StopCharging;
    }

    private void StartCharging()
    {
        if (!_canShoot) return;

        _currentDamage = _minDamage;

        CreateBullet<PlasmaBullet>();
        _currentPlasmaBullet = _bullet as PlasmaBullet;

        if (_currentPlasmaBullet != null)
        {
            _currentPlasmaBullet.transform.position = _firePos.position;
            _currentPlasmaBullet.Set(
                new Vector3(_maxBulletSize, _maxBulletSize, _maxBulletSize),
                _growthRate
            );
        }

        OnStartChargingEvent?.Invoke();
    }

    private void UpdateCharging()
    {
        if (!_canShoot || _currentPlasmaBullet == null) return;

        _currentDamage += _chargeRate * Time.deltaTime;
        _currentDamage = Mathf.Clamp(_currentDamage, _minDamage, _weaponData.Damage);

        UpdateBullet();
        OnUpdateChargingEvent?.Invoke();
    }

    private void StopCharging()
    {
        if (!_canShoot || _currentPlasmaBullet == null) return;

        Shoot();
        OnEndChargingEvent?.Invoke();
    }

    protected override void Shoot()
    {
        base.Shoot();

        _currentDamage = _minDamage;
    }

    protected override void ShootProcessing()
    {
        SetBulletTransform(_firePos);
        BulletDirection<PlasmaBullet>(_currentPlasmaBullet, _firePos);
        ShootBullet(_currentPlasmaBullet.transform.forward * _weaponData.BulletSpeed);
    }

    private void UpdateBullet()
    {
        if (_currentPlasmaBullet != null)
        {
            _currentPlasmaBullet.transform.position = _firePos.position;
            _currentPlasmaBullet.Scale();
        }
    }
}