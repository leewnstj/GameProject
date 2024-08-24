using System.Collections;
using UnityEngine;

public class PlasmaBullet : Bullet
{
    private Vector3 _originalSize;
    private Vector3 _maxSize;
    private float _growthRate;

    protected override void Awake()
    {
        base.Awake();

        _originalSize = transform.localScale; // 초기 사이즈 저장
    }

    public void Set(Vector3 maxSize, float growthRate)
    {
        _maxSize = maxSize;
        _growthRate = growthRate;
    }

    public void Scale()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, _maxSize, _growthRate * Time.deltaTime);

        if (Vector3.Distance(transform.localScale, _maxSize) < 0.01f)
        {
            transform.localScale = _maxSize;
        }
    }

    protected override void OnHit()
    {
        base.OnHit();

        transform.localScale = _originalSize;
    }
}