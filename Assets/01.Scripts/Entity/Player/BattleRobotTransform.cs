public class BattleRobotTransform
{
    private StateMachine _ownerStateMachine;

    private bool _canTranfrom = true;
    private bool _isRobot = true;

    public BattleRobotTransform(StateMachine owner)
    {
        _ownerStateMachine = owner;
    }

    public void TransformRobot(float transformCoolTime)
    {
        if (_canTranfrom)
        {
            _canTranfrom = false;

            if (_isRobot)
                _ownerStateMachine.ChangeState(EntityStateEnum.ChangeRoll);
            else
                _ownerStateMachine.ChangeState(EntityStateEnum.StopRoll);

            _isRobot = !_isRobot;

            CoroutineUtil.CallWaitForSeconds(transformCoolTime, () => _canTranfrom = true);
        }
    }
}