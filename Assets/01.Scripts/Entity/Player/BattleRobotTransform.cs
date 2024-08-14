public class BattleRobotTransform
{
    private StateMachine _ownerStateMachine;

    private bool _canTranfrom = true;
    private bool _isRobotForm = true;

    public BattleRobotTransform(StateMachine owner)
    {
        _ownerStateMachine = owner;
    }

    public void TransformRobot(float transformCoolTime)
    {
        if (!_canTranfrom) return;

        _canTranfrom = false;

        ChangeStateBasedOnForm();

        _isRobotForm = !_isRobotForm;

        CoroutineUtil.CallWaitForSeconds(transformCoolTime, () => _canTranfrom = true);
    }

    private void ChangeStateBasedOnForm()
    {
        if (_isRobotForm)
            _ownerStateMachine.ChangeState(EntityStateEnum.ChangeRoll);
        else
            _ownerStateMachine.ChangeState(EntityStateEnum.StopRoll);
    }
}