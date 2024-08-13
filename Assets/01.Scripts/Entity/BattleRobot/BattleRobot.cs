using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobot : Entity
{
    [SerializeField] private InputSystem _inputReader;

    public Vector2 Direction => EntityMovementCompo.Direction;
    public bool IsMove       => EntityMovementCompo.IsMove;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        _inputReader.OnMoveEvent      += EntityMovementCompo.SetDirection;
        _inputReader.OnTransformEvent += BattleRobotTransform;
    }

    private void OnDisable()
    {
        _inputReader.OnMoveEvent      -= EntityMovementCompo.SetDirection;
        _inputReader.OnTransformEvent -= BattleRobotTransform;
    }

    private void Start()
    {
        StateMachine.Init(EntityStateEnum.Open);
    }

    public void BattleRobotTransform()
    {
        RobotState curState = StateMachine.CurrentState as RobotState;

        if(curState.IsRobot)
        {
            StateMachine.ChangeState(EntityStateEnum.ChangeRoll);
        }
        else
        {
            StateMachine.ChangeState(EntityStateEnum.StopRoll);
        }
    }
}