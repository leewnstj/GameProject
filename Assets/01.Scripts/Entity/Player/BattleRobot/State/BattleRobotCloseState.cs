using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotCloseState : RobotState
{
    public BattleRobotCloseState(Entity entity, StateMachine stateMachine, string animationBoolName) : base(entity, stateMachine, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _robot.SetTransform(false);
        _robot.SetRotation(false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {

    }
}