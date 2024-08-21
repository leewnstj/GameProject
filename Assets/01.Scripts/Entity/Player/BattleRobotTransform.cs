/// <summary>
/// 전투 로봇의 모드(전투모드, 공모드)를 바꿔주는 
/// </summary>
public class BattleRobotTransform : IEventPublisher
{
    private StateMachine _ownerStateMachine;
    protected float _coolTime;

    private bool _coolTimeComplete = true;
    private bool _isRobotForm = true;
    private bool _canTransform;

    public void SetInit(StateMachine owner, float coolTime)
    {
        _ownerStateMachine = owner;

        _coolTime = coolTime;
    }

    public void SubscribeEvent()
    {
        InputManager.OnTransformEvent += TransformRobot;
    }

    public void UnSubscribeEvent()
    {
        InputManager.OnTransformEvent -= TransformRobot;
    }

    public void SetTransform(bool value) => _canTransform = value;

    private void TransformRobot()
    {
        if (_canTransform)
            TransformRobot(_coolTime);
    }

    public void TransformRobot(float transformCoolTime)
    {
        if (!_coolTimeComplete) return;

        _coolTimeComplete = false;

        ChangeStateBasedOnForm();

        _isRobotForm = !_isRobotForm;

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