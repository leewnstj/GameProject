using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotCloseState : PlayerState
{
    public BattleRobotCloseState(Entity entity, StateMachine stateMachine, string animationBoolName) : base(entity, stateMachine, animationBoolName)
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

    }
}