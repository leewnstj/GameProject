using System;

/// <summary>
/// 전투 로봇의 모드(전투모드, 공모드)를 바꿔주는 
/// </summary>
public class BattleRobotTransform
{
    private StateMachine _ownerStateMachine;
    protected float _coolTime;

    private bool _coolTimeComplete = true;
    private bool _canTransform;
    private bool _isRobotForm = true;

    public void SetInit(StateMachine owner, float coolTime)
    {
        _ownerStateMachine = owner;

        _coolTime = coolTime;
    }

    public void SetTransform(bool value) => _canTransform = value;

    public void TransformRobot()
    {
        if (_canTransform)
            Transforming(_coolTime);
    }

    public void Transforming(float transformCoolTime)
    {
        if (!_coolTimeComplete) return;

        _coolTimeComplete = false;

        ChangeStateBasedOnForm();

        _isRobotForm = !_isRobotForm;

        SignalHub.OnChangedRobotFormEvent(_isRobotForm);

        CoroutineUtil.CallWaitForSeconds(transformCoolTime, () => _coolTimeComplete = true);
    }

    private void ChangeStateBasedOnForm()
    {
        if (_isRobotForm)
            _ownerStateMachine.ChangeState(EntityStateEnum.ChangeRoll);
        else
            _ownerStateMachine.ChangeState(EntityStateEnum.StopRoll);
    }
}