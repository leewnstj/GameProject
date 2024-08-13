using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/BattleRobot")]
public class BattleRobotSO : ScriptableObject
{
    [Header("Robot Transform")]
    public float TransformTime;
    public float TransformCoolTime;

    [Header("Reload")]
    public float ReloadTime;
    public float BulletReloadAmount;

    [Header("Stat")]
    public float MaxHealth;
    public float MoveSpeed;
}