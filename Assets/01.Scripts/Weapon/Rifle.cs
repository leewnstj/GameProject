using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MK.Toon;
using Unity.VisualScripting;

public class Rifle : Weapon
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