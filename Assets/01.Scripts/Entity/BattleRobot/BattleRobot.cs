using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobot : Entity
{
    public StateMachine StateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        StateMachine = new StateMachine();

        foreach (EntityStateEnum state in Enum.GetValues(typeof(EntityStateEnum)))
        {
            string typeName = state.ToString();
            Type t = Type.GetType($"Penguin{typeName}State");

            State newState = Activator.CreateInstance(t, this, StateMachine, typeName) as State;
            
            if (newState == null)
            {
                Debug.LogError($"There is no script : {state}");
                return;
            }

            StateMachine.AddState(state, newState);
        }
    }
}
