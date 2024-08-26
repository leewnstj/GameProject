using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotWalkState : PlayerState
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
        base.Update();

        if (!_movement.IsMove)
        {
            _stateMachine.ChangeState(EntityStateEnum.Idle);
        }
    }
}