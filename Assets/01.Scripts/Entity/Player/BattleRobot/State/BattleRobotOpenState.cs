using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotOpenState : RobotState
{
    public BattleRobotOpenState(Entity entity, StateMachine stateMachine, string animationBoolName) : base(entity, stateMachine, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        _robot.SetTransform(true);
    }

    public override void Update()
    {
        if(_triggerCalled)
        {
            _stateMachine.ChangeState(EntityStateEnum.Idle);
        }
    }
}