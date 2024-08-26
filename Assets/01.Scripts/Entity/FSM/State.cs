using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected StateMachine _stateMachine;
    protected Entity _owner;

    protected int _animBoolHash;
    protected bool _triggerCalled = true;

    protected bool _canInteraction = true;

    public bool CanInteraction => _canInteraction;

    public State(Entity entity, StateMachine stateMachine, string animationBoolName)
    {
        _animBoolHash = Animator.StringToHash(animationBoolName);

        _owner = entity;
        _stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        _triggerCalled = false;
        _owner.AnimatorCompo.SetBool(_animBoolHash, true);
    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {
        _owner.AnimatorCompo.SetBool(_animBoolHash, false);
    }

    public virtual void ExcludingInteraction()
    {
        _canInteraction = false;
    }

    public void AnimatorFinishTrigger()
    {
        _triggerCalled = true;
    }
}