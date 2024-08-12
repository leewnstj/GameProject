using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Animator AnimatorCompo { get; set; }

    protected virtual void Awake()
    {
        AnimatorCompo = GetComponentInChildren<Animator>();
    }

    public void AnimationTrigger()
    {

    }
}