using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotController : MonoBehaviour
{
    [SerializeField] private BattleRobot _battleRobotPrefab;
    [SerializeField] private BattleRobotDrone _battleRobotDronePrefab;

    private void Start()
    {
        _battleRobotDronePrefab.SetTarget(_battleRobotPrefab.DroneTarget);
    }
}