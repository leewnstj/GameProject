using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/BattleRobot")]
public class BattleRobotSO : RobotSO
{
    [Header("BattleRobotStat")]
    public float RollSpeed;

    [Header("Robot Transform")]
    public float TransformTime;
    public float TransformCoolTime;
}