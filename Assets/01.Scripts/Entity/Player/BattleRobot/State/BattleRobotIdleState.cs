using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotIdleState : RobotState
{
    public BattleRobotIdleState(Entity entity, StateMachine stateMachine, string animationBoolName) : base(entity, stateMachine, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _robot.PlayerMovementCompo.StopImmediately();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if(_robot.IsMove)
        {
            _stateMachine.ChangeState(EntityStateEnum.Walk);
        }
    }
}