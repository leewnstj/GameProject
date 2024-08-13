using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotChangeRollState : RobotState
{
    public BattleRobotChangeRollState(Entity entity, StateMachine stateMachine, string animationBoolName) : base(entity, stateMachine, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        IsRobot = false;
    }

    public override void Update()
    {
        if(_triggerCalled)
        {
            _stateMachine.ChangeState(EntityStateEnum.Roll);
        }
    }
}