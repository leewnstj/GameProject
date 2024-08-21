using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private PoolListSO _poolList;

    private void Start()
    {
        MakePool();
    }

    public void MakePool()
    {
        PoolManager.Instance = new PoolManager(transform);

        _poolList.ObjectPool.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount));
        _poolList.EntityPool.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount));
        _poolList.EffectPool.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount));
    }
}