using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    private void OnEnable()
    {
        PlayerHub.OnLeftMouseEvent += Shoot;
    }

    private void OnDisable()
    {
        PlayerHub.OnLeftMouseEvent -= Shoot;
    }
}