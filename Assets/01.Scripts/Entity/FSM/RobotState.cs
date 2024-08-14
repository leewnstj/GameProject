using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotState : State
{
    protected BattleRobot _robot;
    protected BattleRobotSO _so => _robot.RobotSO;


    public RobotState(Entity entity, StateMachine stateMachine, string animationBoolName) : base(entity, stateMachine, animationBoolName)
    {
        _robot = entity as BattleRobot;
    }

    public override void Update()
    {
        base.Update();

        _robot.EntityMovementCompo.Movement(_so.MoveSpeed, false);

        _robot.RobotRotateCompo.RotateTowardsMouse(_so.RotateSpeed);
    }
} 