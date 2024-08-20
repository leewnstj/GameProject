using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobot : Player
{
    public bool CanTransform { get; private set; } = false;

    private BattleRobotTransform _robotTransform;

    protected override void Awake()
    {
        base.Awake();

        _robotTransform = EventFactoryCompo.CreateEntityComponent<BattleRobotTransform>();
        _robotTransform.SetInit(StateMachine, RobotSO.TransformCoolTime);
    }

    private void Start()
    {
        StateMachine.Init(EntityStateEnum.Open);
    }

    public void SetTransform(bool value)
    {
        _robotTransform.SetTransform(value);
    }
}