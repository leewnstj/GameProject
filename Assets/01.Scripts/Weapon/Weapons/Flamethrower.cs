using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Weapon
{
    private void OnEnable()
    {
        InputManager.OnLeftMouseEvent += Shoot;
    }

    private void OnDisable()
    {
        InputManager.OnLeftMouseEvent -= Shoot;
    }
}