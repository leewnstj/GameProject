using UnityEngine;

public class CreateElectricEffect : MonoBehaviour, IParticle
{
    [SerializeField] private float _maxEffectScale;
    [SerializeField] private float _effectGrowthRate = 0.1f;
    [SerializeField] private ElectricEffect _electricParticle;

    private ElectricEffect _currentParticle;
    private float _currentEffectSize = 0f;

    // 파티클 생성
    public void CreateParticle()
    {
        if (_currentParticle != null)
        {
            DestroyParticle();
        }

        _currentParticle = PoolManager.Pop(_electricParticle.name) as ElectricEffect;

        if (_currentParticle != null)
        {
            _currentParticle.transform.SetParent(transform.parent);
            _currentParticle.transform.position = transform.position;
            _currentParticle.SetMaxScale(_maxEffectScale);
            _currentEffectSize = 0f; // 초기 사이즈 설정
        }
    }

    // 파티클 업데이트
    public void UpdateParticle()
    {
        if (_currentParticle == null) return;

        _currentEffectSize += _effectGrowthRate * Time.deltaTime;
        _currentEffectSize = Mathf.Clamp(_currentEffectSize, 0f, _maxEffectScale);

        _currentParticle.Scale(_currentEffectSize);
    }

    // 파티클 파괴
    public void DestroyParticle()
    {
        if (_currentParticle != null)
        {
            _currentEffectSize = 0f;
            _currentParticle.ResetEffect();
            PoolManager.Push(_currentParticle);
            _currentParticle = null;
        }
    }
}
