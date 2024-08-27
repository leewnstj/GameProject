using ComponentPattern;
using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// 전투 로봇의 모드(전투모드, 공모드)를 바꿔주는 
/// </summary>
public class BattleRobotTransform : MonoBehaviour, IEntityComponent
{
    private StateMachine _ownerStateMachine;
    protected float _coolTime;

    private bool _coolTimeComplete = true;
    private bool _canTransform => _ownerStateMachine.CurrentState.CanInteraction;
    private bool _isRobotForm = true;

    public void Init(Entity component)
    {
        _ownerStateMachine = component.StateMachine;
        _coolTime = component.RobotSO.TransformCoolTime;
    }

    private void OnEnable()
    {
        InputManager.OnTransformEvent += TransformRobot;
    }

    private void OnDisable()
    {
        InputManager.OnTransformEvent -= TransformRobot;
    }

    public void TransformRobot()
    {
        if (_canTransform)
            Transforming();
    }

    public void Transforming()
    {
        if (!_coolTimeComplete) return;

        _coolTimeComplete = false;

        ChangeStateBasedOnForm();

        _isRobotForm = !_isRobotForm;

        SignalHub.OnChangedRobotFormEvent(_isRobotForm);

        StartCoroutine(TransformCoolCoroutine());
    }

    private IEnumerator TransformCoolCoroutine()
    {
        yield return new WaitForSeconds(_coolTime);
        _coolTimeComplete = true;
    }

    private void ChangeStateBasedOnForm()
    {
        if (_isRobotForm)
            _ownerStateMachine.ChangeState(EntityStateEnum.ChangeRoll);
        else
            _ownerStateMachine.ChangeState(EntityStateEnum.StopRoll);
    }
}