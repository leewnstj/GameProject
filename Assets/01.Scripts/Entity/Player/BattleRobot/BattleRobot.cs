using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobot : Entity
{
    [SerializeField] private BattleRobotSO _robotSO;
    [SerializeField] private InputSystem _inputReader;

    public Vector2 Direction => EntityMovementCompo.Direction;
    public bool IsMove       => EntityMovementCompo.IsMove;
    public BattleRobotSO RobotSO { get; private set;}

    private bool _canTranfrom = true;
    private bool _isRobot = true;

    protected override void Awake()
    {
        base.Awake();

        RobotSO = Instantiate(_robotSO);
    }

    private void OnEnable()
    {
        _inputReader.OnMoveEvent += EntityMovementCompo.SetDirection;
        _inputReader.OnTransformEvent += TransformRobot;
    }

    private void OnDisable()
    {
        _inputReader.OnMoveEvent -= EntityMovementCompo.SetDirection;
        _inputReader.OnTransformEvent -= TransformRobot;
    }

    private void Start()
    {
        StateMachine.Init(EntityStateEnum.Open);
    }

    public void TransformRobot()
    {
        if (_canTranfrom)
        {
            _canTranfrom = false;

            if (_isRobot)
                StateMachine.ChangeState(EntityStateEnum.ChangeRoll);
            else
                StateMachine.ChangeState(EntityStateEnum.StopRoll);

            _isRobot = !_isRobot;

            StartCoroutine(TransformCoolTime(RobotSO.TransformCoolTime));
        }
    }

    private IEnumerator TransformCoolTime(float coolTime)
    {
        yield return new WaitForSeconds(coolTime);
        _canTranfrom = true;
    }
}