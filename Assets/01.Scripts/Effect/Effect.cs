using UnityEngine;

namespace ProjectEffect
{
    public class Effect : PoolableMono
    {
        public float Duration => _particleSystem.main.duration;

        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        public void ResetPosition()
        {
            transform.localPosition = Vector3.zero;
        }

        public void OnLoop(bool value)
        {
            var main = _particleSystem.main;
            main.loop = value;
        }

        public void Play()
        {
            _particleSystem.Play();
        }

        public void Stop()
        {
            _particleSystem.Stop();
        }
    }
}