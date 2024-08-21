using DG.Tweening;
using UnityEngine;

public class PlasmaGun : Weapon
{
    [SerializeField] private Transform _muzzle;
    [SerializeField] private float _minDamage;
    [SerializeField] private float _chargeRate = 10f;
    [SerializeField] private float _rotateSpeed;

    [SerializeField] private ParticleSystem _electricPartice;

    private ParticleSystem _currentParticle;
    private float _currentDamage;

    private void OnEnable()
    {
        InputManager.OnLeftMouseDownEvent += CreateElectricEffect;
        InputManager.OnLeftMouseEvent     += ChargingGuage;
        InputManager.OnLeftMouseEvent     += RotationMuzzle;
        InputManager.OnLeftMouseUpEvent   += Shoot;
    }

    private void OnDisable()
    {
        InputManager.OnLeftMouseDownEvent -= CreateElectricEffect;
        InputManager.OnLeftMouseEvent     -= ChargingGuage;
        InputManager.OnLeftMouseEvent     -= RotationMuzzle;
        InputManager.OnLeftMouseUpEvent   -= Shoot;
    }

    private void CreateElectricEffect()
    {
        if (_maxBullet <= 0 || _delayShoot) return;

        _currentParticle = Instantiate(_electricPartice, transform);
        _currentParticle.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        _currentParticle.transform.position = _muzzle.transform.position;
    }

    private void ChargingGuage()
    {
        if (_maxBullet <= 0 || _delayShoot) return;

        _currentDamage += _chargeRate * Time.deltaTime;

        _currentDamage = Mathf.Clamp(_currentDamage, _minDamage, _weaponData.Damage);
    }

    private void RotationMuzzle()
    {
        if (_maxBullet <= 0 || _delayShoot) return;

        _muzzle.transform.Rotate(new Vector3(0, _currentDamage, 0) * Time.deltaTime * _rotateSpeed);
    }

    protected override void Shoot()
    {
        base.Shoot();

        _currentDamage = _minDamage;
        Destroy(_currentParticle);
    }
}