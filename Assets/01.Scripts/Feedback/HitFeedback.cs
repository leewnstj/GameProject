using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFeedback : Feedback
{
    [SerializeField] private EffectEnum _effectType;

    private Effect _effect;

    public override void CreateFeedback()
    {
        _effect = PoolManager.Pop(_effectType.ToString()) as Effect;
        _effect.transform.position = transform.position;
    }

    public override void FinishFeedback()
    {
        CoroutineUtil.CallWaitForSeconds(_effect.Duration, () => PoolManager.Push(_effect));
    }
}