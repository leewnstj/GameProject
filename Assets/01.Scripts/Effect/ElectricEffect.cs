using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ElectricEffect : Effect
{
    private ParticleSystem[] _particles;
    private List<MinMaxCurve> _startSize = new();

    private float _maxSize;

    private void Awake()
    {
        _particles = GetComponentsInChildren<ParticleSystem>();

        foreach(var particle in _particles)
        {
            var mainModule = particle.main;

            _startSize.Add(mainModule.startSize);
        }
    }

    public void Set(float maxScale)
    {
        _maxSize = maxScale;
    }

    public void Scale(float scale)
    {
        foreach (var particle in _particles)
        {
            var mainModule = particle.main;

            // 기존 크기에 scale만큼 더한 후 maxSize를 초과하지 않도록 제한
            float newSize = Mathf.Clamp(mainModule.startSize.constant + scale, 0, _maxSize);

            // 새로운 크기로 설정
            mainModule.startSize = newSize;
        }
    }

    public void ResetEffect()
    {
        //크기를 초기값으로 리셋
        for(int i = 0; i <  _particles.Length; i++)
        {
            var mainModule = _particles[i].main;

            mainModule.startSize = _startSize[i];
        }
    }
}