using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotStopRollState : RobotState
{
    public BattleRobotStopRollState(Entity entity, StateMachine stateMachine, string animationBoolName) : base(entity, stateMachine, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        IsRobot = true;
    }

    public override void Update()
    {
        base.Update();

        if(_triggerCalled)
        {
            _stateMachine.ChangeState(EntityStateEnum.Idle);
        }
    }
}