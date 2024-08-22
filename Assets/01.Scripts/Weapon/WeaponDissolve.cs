using DG.Tweening;
using System;
using UnityEngine;

public partial class Weapon
{
    private MeshRenderer[] _meshRenderers;

    private void Awake()
    {
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    public void Dissolve(float value, float duration, Action onEndDissolveAction = null)
    {
        foreach (var meshRenderer in _meshRenderers)
        {
            meshRenderer.Dissolve(value, duration, onEndDissolveAction);
        }
    }
}