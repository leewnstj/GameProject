using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntityAnimationTrigger : MonoBehaviour
{
    public UnityEvent OnActionEvent = null;
    private Entity _entity;

    private void Awake()
    {
        _entity = transform.parent.GetComponent<Entity>();
    }

    public void AnimationEventTrigger()
    {
        OnActionEvent?.Invoke();
    }

    public void EndAnimationTrigger()
    {
        _entity.AnimationTrigger();
    }
}