using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Robot")]
public class RobotSO : ScriptableObject
{
    [Header("Robot Stat")]

    public float MaxHealth;
    public float MoveSpeed;
    public float RotateSpeed;
}