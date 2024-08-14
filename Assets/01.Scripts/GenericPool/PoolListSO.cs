using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PoolingPair
{
    public PoolableMono prefab;
    public int poolCount;
}

[CreateAssetMenu(menuName = "SO/Pool/list")]
public class PoolListSO : ScriptableObject
{
    public List<PoolingPair> EntityPool = new();
    public List<PoolingPair> EffectPool = new();
    public List<PoolingPair> ObjectPool = new();
}
