using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotWalkState : RobotState
{
    public BattleRobotWalkState(Entity entity, StateMachine stateMachine, string animationBoolName) : base(entity, stateMachine, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        _robot.EntityMovementCompo.Movement(10f);

        if (!_robot.IsMove)
        {
            _stateMachine.ChangeState(EntityStateEnum.Idle);
        }
    }
}