using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Weapon
{
    [SerializeField] private Effect _flamethrowerEffect;

    private Effect _currentEffect;

    private void OnEnable()
    {
        InputManager.OnLeftMouseDownEvent += StartShooting;
        InputManager.OnLeftMouseEvent     += Shooting;
        InputManager.OnLeftMouseUpEvent   += EndShooting;
    }

    private void OnDisable()
    {
        InputManager.OnLeftMouseDownEvent -= StartShooting;
        InputManager.OnLeftMouseEvent     -= Shooting;
        InputManager.OnLeftMouseUpEvent   -= EndShooting;
    }

    private void StartShooting()
    {
        CreateParticle();
    }

    private void Shooting()
    {

    }

    private void EndShooting()
    {
        DestroyParticle();
    }

    #region Particle

    private void CreateParticle()
    {
        if(_currentEffect != null)
        {
            DestroyParticle();
        }

        _currentEffect = PoolManager.Pop(_flamethrowerEffect.name) as Effect;
        _currentEffect.transform.SetParent(transform);
        _currentEffect.transform.position = _firePos.position;
        _currentEffect.transform.rotation = _firePos.rotation;
    }

    private void DestroyParticle()
    {
        PoolManager.Push(_currentEffect);
        _currentEffect = null;
    }

    #endregion
}