using ComponentPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : EntityMovement, IPlayerComponent
{
    public void Init(Player component)
    {
        _rigidbodyCompo = component.RigidbodyCompo;
    }

    private void OnEnable()
    {
        InputManager.OnMoveEvent += SetDirection;
    }

    private void OnDisable()
    {
        InputManager.OnMoveEvent -= SetDirection;
    }
}