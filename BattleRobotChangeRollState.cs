using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotChangeRollState : State
{
    public BattleRobotChangeRollState(Entity entity, StateMachine stateMachine, string animationBoolName) : base(entity, stateMachine, animationBoolName)
    {
    }
}
