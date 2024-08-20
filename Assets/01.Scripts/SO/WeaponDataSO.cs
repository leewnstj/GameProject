using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon")]
public class WeaponDataSO : ScriptableObject
{
    [Header("Weapon")]
    public float Damage;

    [Range(0, 100)] public int AmmoCapacity = 100;

    [Range(0f, 2f)] public float WeaponDelay = 0.05f;
    [Range(0, 10f)] public float SpreadAngle = 5f;

    [Header("Bullet")]
    public int BulletCount = 1;
    public float BulletSpeed;

    [Header("Reload")]
    public float ReloadTime = 1f;
    public AudioClip ReloadClip;
}