using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobot : Robot
{
    #region Component

    private BattleRobotTransform _robotTransform;

    #endregion

    protected override void Awake()
    {
        base.Awake();

        _robotTransform = new(StateMachine);
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        InputSystem.OnTransformEvent += TransformRobot;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        InputSystem.OnTransformEvent -= TransformRobot;
    }

    private void Start()
    {
        StateMachine.Init(EntityStateEnum.Open);
    }
    
    private void TransformRobot()
    {
        _robotTransform.TransformRobot(RobotSO.TransformCoolTime);
    }
}