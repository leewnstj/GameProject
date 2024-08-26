using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotRollState : PlayerState
{
    public BattleRobotRollState(Entity entity, StateMachine stateMachine, string animationBoolName) : base(entity, stateMachine, animationBoolName)
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
        _movement.Movement(_so.RollSpeed);
    }
}
