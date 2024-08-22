using DG.Tweening;
using System;
using UnityEngine;

/// <summary>
/// 확장 메서드 모음
/// </summary>
public static class Extension
{
    /// <summary>
    /// MeshRenderer의 메테리얼 Dissolve
    /// </summary>
    /// <param name="meshRenderer"></param>
    /// <param name="amount"></param>
    /// <param name="duration"></param>
    /// <param name="onEndDissolveAction"></param>
    public static void Dissolve(this MeshRenderer meshRenderer, float amount, float duration, Action onEndDissolveAction = null)
    {
        meshRenderer.material.DOFloat(amount, "_DissolveAmount", duration);

        CoroutineUtil.CallWaitForSeconds(duration, onEndDissolveAction);
    }
}