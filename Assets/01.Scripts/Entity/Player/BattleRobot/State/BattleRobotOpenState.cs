using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotOpenState : PlayerState
{
    public BattleRobotOpenState(Entity entity, StateMachine stateMachine, string animationBoolName) : base(entity, stateMachine, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        ExcludingInteraction();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if(_triggerCalled)
        {
            _stateMachine.ChangeState(EntityStateEnum.Idle);
        }
    }
}