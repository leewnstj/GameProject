using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Entity
{
    [SerializeField] private InputSystem   _inputReader;
    [SerializeField] private BattleRobotSO _robotSO;

    public bool IsMove => EntityMovementCompo.IsMove;

    public InputSystem InputSystem => _inputReader;
    public BattleRobotSO RobotSO   { get; private set; }

    #region Component

    public RobotRotation RobotRotateCompo { get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();

        RobotRotateCompo = new(transform); 
        RobotSO = Instantiate(_robotSO);
    }

    protected override void SubscribeEvent()
    {
        InputSystem.OnMoveEvent += EntityMovementCompo.SetDirection;
    }

    protected override void UnsubscribeEvent()
    {
        InputSystem.OnMoveEvent -= EntityMovementCompo.SetDirection;
    }
}
