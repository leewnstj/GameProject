using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CurrentState { get; private set; }

    public Dictionary<EntityStateEnum, State> StateDictionary = new();

    public void Init(EntityStateEnum state)
    {
        CurrentState = StateDictionary[state];
        CurrentState.Enter();
    }

    public void ChangeState(EntityStateEnum state)
    {
        CurrentState.Exit();
        CurrentState = StateDictionary[state];
        CurrentState.Enter();
    }

    public void AddState(EntityStateEnum stateType, State state)
    {
        StateDictionary.Add(stateType, state);
    }
}