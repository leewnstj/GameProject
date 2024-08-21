using System;
using UnityEngine;

// 추상 클래스 Entity는 PoolableMono 및 IEventPublisher 인터페이스를 상속받는다.
public abstract class Entity : PoolableMono
{
    [Header("Entity")]

    [SerializeField] private EntityType _entityType;  // Entity의 타입을 나타낸다.
    [SerializeField] protected BattleRobotSO _robotSO;

    #region 컴포넌트 선언

    public Animator AnimatorCompo { get; private set; }  // Animator 컴포넌트
    public Rigidbody RigidbodyCompo { get; private set; }  // Rigidbody 컴포넌트
    public EntityMovement EntityMovementCompo { get; private set; }  // EntityMovement 컴포넌트
    public EventFactory EventFactoryCompo { get; private set; }

    #endregion

    public EntityType EntityType => _entityType;

    public StateMachine StateMachine { get; private set; }

    private IEventPublisher[] _eventPublishers;

    // 객체가 생성될 때 호출되는 메서드
    protected virtual void Awake()
    {
        // Factory 초기화
        EventFactoryCompo = new EventFactory();

        // 컴포넌트 초기화
        AnimatorCompo = GetComponentInChildren<Animator>();
        RigidbodyCompo = GetComponent<Rigidbody>();

        // 자식 오브젝트에 있는 IEventPublisher 컴포넌트 가져오기
        _eventPublishers = GetComponentsInChildren<IEventPublisher>();

        // 상태 머신 초기화
        InitializeStateMachine();
    }

    private void OnEnable()
    {
        SubscribeAllEvents();
    }

    private void OnDisable()
    {
        UnsubscribeAllEvents();
    }

    private void SubscribeAllEvents()
    {
        foreach (var publisher in _eventPublishers)
        {
            publisher.SubscribeEvent();
        }
    }

    private void UnsubscribeAllEvents()
    {
        foreach (var publisher in _eventPublishers)
        {
            publisher.UnSubscribeEvent();
        }
    }


    protected virtual void FixedUpdate()
    {
        if (StateMachine.IsUpdate)
        {
            StateMachine.CurrentState.Update();
        }
    }


    protected void InitializeStateMachine()
    {
        StateMachine = new StateMachine();

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


    public void AnimationTrigger()
    {
        StateMachine.CurrentState.AnimatorFinishTrigger();
    }
}