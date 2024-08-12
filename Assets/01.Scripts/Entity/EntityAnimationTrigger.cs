using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimationTrigger : MonoBehaviour
{
    private Entity _entity;

    private void Awake()
    {
        _entity = transform.parent.GetComponent<Entity>();
    }

    public void EndAnimationTrigger()
    {
        _entity.AnimationTrigger();
    }
}