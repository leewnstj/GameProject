using UnityEngine;

public class BattleRobot : Player
{
    [Header("Battle Robot")]

    [SerializeField] private Transform _droneTarget;
    public Transform DroneTarget => _droneTarget;

    public bool CanTransform { get; private set; } = false;

    private BattleRobotTransform _robotTransform;

    protected override void Awake()
    {
        base.Awake();

        _robotTransform = new();
        _robotTransform.SetInit(StateMachine, RobotSO.TransformCoolTime);
    }

    private void Start()
    {
        StateMachine.Init(EntityStateEnum.Open);
    }

    protected override void SubscribeFunction()
    {
        base.SubscribeFunction();

        InputManager.OnTransformEvent += _robotTransform.TransformRobot;
    }

    protected override void UnsubscribeFunction()
    {
        base.UnsubscribeFunction();

        InputManager.OnTransformEvent -= _robotTransform.TransformRobot;
    }

    /// <summary>
    /// 전투 로봇 변환 제약
    /// </summary>
    /// <param name="value">전투 로봇이 변환 가능한지 여부</param>
    public void SetTransform(bool value)
    {
        _robotTransform.SetTransform(value);
    }
}