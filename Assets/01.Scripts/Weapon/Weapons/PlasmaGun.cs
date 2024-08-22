using UnityEngine;

public class PlasmaGun : Weapon
{
    [Header("PlasmaGun")]
    [SerializeField] private Transform _muzzle;
    [SerializeField] private ParticleSystem _electricPartice;

    [SerializeField] private float _maxEffectScale;
    [SerializeField] private float _minDamage;
    [SerializeField] private float _chargeRate = 10f;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _effectGrowthRate = 0.1f;


    private ElectricEffect _currentParticle;
    private float _currentDamage;
    private float _currentEffectSize = 0;


    private void OnEnable()
    {
        InputManager.OnLeftMouseDownEvent += StartCharging;
        InputManager.OnLeftMouseEvent += UpdateCharging;
        InputManager.OnLeftMouseEvent += RotateMuzzle;
        InputManager.OnLeftMouseUpEvent += Shoot;
    }

    private void OnDisable()
    {
        InputManager.OnLeftMouseDownEvent -= StartCharging;
        InputManager.OnLeftMouseEvent -= UpdateCharging;
        InputManager.OnLeftMouseEvent -= RotateMuzzle;
        InputManager.OnLeftMouseUpEvent -= Shoot;
    }


    private void StartCharging()
    {
        if (_maxBullet <= 0 || _delayShoot) return;

        CreateParticle();

        _currentDamage = _minDamage;
    }


    private void UpdateCharging()
    {
        if (_maxBullet <= 0 || _delayShoot) return;

        _currentDamage += _chargeRate * Time.deltaTime;
        _currentDamage = Mathf.Clamp(_currentDamage, _minDamage, _weaponData.Damage);

        UpdaeParticle();
    }


    private void RotateMuzzle()
    {
        if (_maxBullet <= 0 || _delayShoot) return;

        _muzzle.transform.Rotate(Vector3.up * _currentDamage * _rotateSpeed * Time.deltaTime);
    }


    protected override void Shoot()
    {
        base.Shoot();

        _currentDamage = _minDamage;
        _currentEffectSize = 0;

        DestroyParticle();
    }

    #region Particle

    private void CreateParticle()
    {
        _currentParticle = PoolManager.Pop(_electricPartice.name) as ElectricEffect;
        _currentParticle.transform.SetParent(transform);
        _currentParticle.transform.position = _firePos.position;
        _currentParticle.Set(_maxEffectScale);
    }

    private void UpdaeParticle()
    {
        _currentEffectSize += _effectGrowthRate * Time.deltaTime;
        _currentEffectSize = Mathf.Clamp(_currentEffectSize, 0, _maxEffectScale); // 최대 크기 제한

        _currentParticle.Scale(_currentEffectSize);
    }

    private void DestroyParticle()
    {
        _currentParticle.ResetEffect();
        PoolManager.Push(_currentParticle);
    }

    #endregion
}