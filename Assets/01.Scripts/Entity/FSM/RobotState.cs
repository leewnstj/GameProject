using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotState : State
{
    protected BattleRobot _robot;
    public bool IsRobot;

    public RobotState(Entity entity, StateMachine stateMachine, string animationBoolName) : base(entity, stateMachine, animationBoolName)
    {
        _robot = entity as BattleRobot;
    }
}