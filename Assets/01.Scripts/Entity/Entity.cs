using System;
using UnityEngine;

/// <summary>
/// Entity는 PoolableMono를 상속받는다.
/// </summary>
public abstract class Entity : PoolableMono
{
    [Header("Entity")]

    [SerializeField] private   EntityType    _entityType;
    [SerializeField] protected BattleRobotSO _robotSO;

    #region 컴포넌트 선언

    public Animator  AnimatorCompo { get; private set; }
    public Rigidbody RigidbodyCompo { get; private set; }

    #endregion

    public EntityType EntityType => _entityType;

    public StateMachine StateMachine { get; private set; }

    protected virtual void Awake()
    {
        AnimatorCompo  = GetComponentInChildren<Animator>();
        RigidbodyCompo = GetComponent<Rigidbody>();
        StateMachine   = new StateMachine();
    }


    protected virtual void FixedUpdate()
    {
        if (StateMachine.IsUpdate)
        {
            StateMachine.CurrentState.Update();
        }
    }

    /// <summary>
    /// 생물체(Entity) FSM 초기화
    /// </summary>
    protected void InitializeStateMachine()
    {
        foreach (EntityStateEnum stateEnum in Enum.GetValues(typeof(EntityStateEnum)))
        {
            string stateName = stateEnum.ToString();
            Type stateType = Type.GetType($"{_entityType}{stateName}State");

            if (stateType == null)
            {
                Debug.LogError($"상태 타입을 찾을 수 없습니다: {_entityType}{stateName}State");
                continue;
            }

            State newState = Activator.CreateInstance(stateType, this, StateMachine, stateName) as State;

            if (newState == null)
            {
                Debug.LogError($"해당 스크립트가 없습니다: {stateEnum}");
                continue;
            }

            StateMachine.AddState(stateEnum, newState);
        }
    }

    /// <summary>
    /// 생물체의 하나의 애니메이션이 끝나면 실행되는 함수
    /// </summary>
    public void AnimationTrigger()
    {
        StateMachine.CurrentState.AnimatorFinishTrigger();
    }
}