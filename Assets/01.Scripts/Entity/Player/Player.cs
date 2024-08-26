using System;
using System.Collections.Generic;
using ComponentPattern;

public class Player : Entity
{
    public BattleRobotSO RobotSO   { get; private set; }

    private Dictionary<Type, IPlayerComponent> _componentDictionary = new();

    protected override void Awake()
    {
        base.Awake();

        RobotSO = Instantiate(_robotSO);

        IPlayerComponent[] compoArr = GetComponentsInChildren<IPlayerComponent>();

        foreach (var component in compoArr)
        {
            _componentDictionary.Add(component.GetType(), component);
        }

        foreach (IPlayerComponent compo in _componentDictionary.Values)
        {
            compo.Init(this);
        }

        InitializeStateMachine();
    }

    public T GetCompo<T>() where T : class
    {
        if (_componentDictionary.TryGetValue(typeof(T), out IPlayerComponent compo))
            return compo as T;

        return default;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}