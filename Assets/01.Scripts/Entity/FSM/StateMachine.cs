using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State CurrentState { get; private set; }

    public Dictionary<EntityStateEnum, State> StateDictionary = new();

    public bool IsUpdate { get; private set; } = true;

    public void Init(EntityStateEnum state)
    {
        CurrentState = StateDictionary[state];
        CurrentState.Enter();
    }

    public void ChangeState(EntityStateEnum state)
    {
        if (IsUpdate)
        {
            CurrentState.Exit();
            IsUpdate = false;
        }
        if (!IsUpdate)
        {
            CurrentState = StateDictionary[state];
            CurrentState.Enter();
            IsUpdate = true;
        }
    }

    public void AddState(EntityStateEnum stateType, State state)
    {
        StateDictionary.Add(stateType, state);
    }
}