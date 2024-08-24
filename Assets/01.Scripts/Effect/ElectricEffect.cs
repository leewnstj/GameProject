using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using ProjectEffect;

public class ElectricEffect : Effect
{
    private ParticleSystem[] _particles;
    private List<MinMaxCurve> _startSize = new();

    private float _maxSize;

    private void Awake()
    {
        _particles = GetComponentsInChildren<ParticleSystem>();

        for (int particleNumber = 0; particleNumber < _particles.Length; particleNumber++)
        {
            var mainModule = _particles[particleNumber].main;

            _startSize.Add(mainModule.startSize);
        }
    }

    public void SetMaxScale(float maxScale)
    {
        _maxSize = maxScale;
    }

    public void Scale(float scale)
    {
        for (int particleNumber = 0; particleNumber < _particles.Length; particleNumber++)
        {
            var mainModule = _particles[particleNumber].main;

            // 기존 크기에 scale만큼 더한 후 maxSize를 초과하지 않도록 제한
            float newSize = Mathf.Clamp(mainModule.startSize.constant + scale, 0, _maxSize);

            // 새로운 크기로 설정
            mainModule.startSize = newSize;
        }
    }

    public void ResetEffect()
    {
        //크기를 초기값으로 리셋
        for(int particleNumber = 0; particleNumber <  _particles.Length; particleNumber++)
        {
            var mainModule = _particles[particleNumber].main;

            mainModule.startSize = _startSize[particleNumber];
        }
    }
}