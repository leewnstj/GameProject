using UnityEngine;
using ProjectEffect;

public class HitFeedback : Feedback
{
    [SerializeField] private EffectEnum _effectType;

    private Effect _effect;

    public void ChangeEffect(EffectEnum type)
    {
        _effectType = type;
    }

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