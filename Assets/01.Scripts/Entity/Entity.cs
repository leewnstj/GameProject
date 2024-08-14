using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : PoolableMono
{
    [SerializeField] private EntityType _entityType;

    #region Component

    public Animator AnimatorCompo { get; set; }
    public Rigidbody RigidbodyCompo { get; set; }
    public EntityMovement EntityMovementCompo { get; set; }

    #endregion

    public EntityType EntityType => _entityType;
    public StateMachine StateMachine { get; private set; }

    protected virtual void Awake()
    {
        AnimatorCompo = GetComponentInChildren<Animator>();
        RigidbodyCompo = GetComponent<Rigidbody>();

        EntityMovementCompo = new EntityMovement(RigidbodyCompo);

        FSM();
    }

    private void OnEnable()
    {
        SubscribeEvent();
    }

    private void OnDisable()
    {
        UnsubscribeEvent();
    }

    protected abstract void SubscribeEvent();

    protected abstract void UnsubscribeEvent();

    protected virtual void FixedUpdate()
    {
        if(StateMachine.IsUpdate) StateMachine.CurrentState.Update();
    }

    protected void FSM()
    {
        StateMachine = new StateMachine();

        foreach (EntityStateEnum state in Enum.GetValues(typeof(EntityStateEnum)))
        {
            string typeName = state.ToString();
            Type type = Type.GetType($"{_entityType.ToString()}{typeName}State");

            if (type == null)
            {
                Debug.LogError($"Type not found: {_entityType.ToString()}{typeName}State");
                return;
            }

            State newState = Activator.CreateInstance(type, this, StateMachine, typeName) as State;

            if (newState == null)
            {
                Debug.LogError($"There is no script : {state}");
                return;
            }

            StateMachine.AddState(state, newState);
        }
    }

    public void AnimationTrigger()
    {
        StateMachine.CurrentState.AnimatorFinishTrigger();
    }
}