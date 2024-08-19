using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFactory
{
    private List<IEventPublisher> _eventPublishers = new List<IEventPublisher>();

    public T CreateEntityComponent<T>() where T : IEventPublisher, new()
    {
        T instance = new T();
        _eventPublishers.Add(instance);
        instance.SubscribeEvent();
        return instance;
    }

    public void Cleanup()
    {
        foreach (var publisher in _eventPublishers)
        {
            publisher.UnSubscribeEvent();
        }
        _eventPublishers.Clear();
    }
}
