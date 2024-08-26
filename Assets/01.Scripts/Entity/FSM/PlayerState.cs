using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    protected BattleRobotSO _so;

    protected PlayerMovement _movement;
    protected PlayerRotation _rotation;


    public PlayerState(Entity entity, StateMachine stateMachine, string animationBoolName) : base(entity, stateMachine, animationBoolName)
    {
        Player player = entity as Player;

        _movement = player.GetCompo<PlayerMovement>();
        _rotation = player.GetCompo<PlayerRotation>();
        _so       = player.RobotSO;
    }

    public override void Update()
    {
        base.Update();

        _rotation.SetRotation(_canInteraction);

        _movement.Movement(_so.MoveSpeed);
    }

    public override void ExcludingInteraction()
    {
        base.ExcludingInteraction();

        _movement.StopImmediately();
        
    }
} 