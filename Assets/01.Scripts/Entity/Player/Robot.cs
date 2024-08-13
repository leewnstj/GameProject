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

    private RobotMouse _robotRotateCompo;

    #endregion

    protected override void Awake()
    {
        base.Awake();

        _robotRotateCompo = new(transform); 
        RobotSO = Instantiate(_robotSO);
    }

    protected virtual void OnEnable()
    {
        InputSystem.OnMoveEvent += EntityMovementCompo.SetDirection;
    }

    protected virtual void OnDisable()
    {
        InputSystem.OnMoveEvent -= EntityMovementCompo.SetDirection;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        _robotRotateCompo.RotateTowardsMouse(_robotSO.RotateSpeed);
    }
}
