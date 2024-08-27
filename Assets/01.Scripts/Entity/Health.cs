using ComponentPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IEntityComponent
{
    private float _maxHP;
    private float _currentHP;

    public bool IsDie => _currentHP <= 0;


    public void Init(Entity component)
    {
        _maxHP = component.RobotSO.MaxHealth;

        _currentHP = _maxHP;
    }

    public void OnDamge(float damage)
    {
        _currentHP -= damage;

        if(IsDie)
        {

        }
    }
}