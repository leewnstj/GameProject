using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobot : Player
{
    public bool CanTransform { get; private set; } = false;

    #region Component

    private BattleRobotTransform _robotTransform;

    #endregion

    protected override void Awake()
    {
        base.Awake();

        _robotTransform = new(StateMachine);
    }

    protected override void SubscribeEvent()
    {
        base.SubscribeEvent();

        PlayerHub.OnTransformEvent += TransformRobot;
    }

    protected override void UnsubscribeEvent()
    {
        base.UnsubscribeEvent();

        PlayerHub.OnTransformEvent -= TransformRobot;
    }

    private void Start()
    {
        StateMachine.Init(EntityStateEnum.Open);
    }

    #region Transform

    private void TransformRobot()
    {
        if(CanTransform)
            _robotTransform.TransformRobot(RobotSO.TransformCoolTime);
    }

    public void SetTransform(bool value)
    {
        CanTransform = value;
    }

    #endregion

    #region Shoot



    #endregion
}