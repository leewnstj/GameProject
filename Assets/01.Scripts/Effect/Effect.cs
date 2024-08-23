using UnityEngine;

public class Effect : PoolableMono
{
    public float Duration => _particleSystem.main.duration;

    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }
}