using ProjectEffect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkFeedback : Feedback
{
    [SerializeField] private EffectEnum _effectType;

    private Effect _effect;

    public override void CreateFeedback()
    {
        if (_effect != null) return;

        _effect = PoolManager.Pop(_effectType.ToString()) as Effect;
        _effect.transform.SetParent(transform);

        _effect.ResetPosition();
        _effect.OnLoop(true);
    }

    public void DestroyEffect()
    {
        if(_effect == null) return;

        _effect.OnLoop(false);
        StartCoroutine(EffectPushCoroutine());
    }

    private IEnumerator EffectPushCoroutine()
    {
        yield return new WaitForSeconds(_effect.Duration);
        PoolManager.Push(_effect);
        _effect = null;
    }

    public override void FinishFeedback()
    {

    }
}