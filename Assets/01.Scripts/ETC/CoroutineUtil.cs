using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineUtil
{
    private static GameObject _coroutineObj;
    private static CoroutineExecutor _coroutineExecutor;

    static CoroutineUtil()
    {
        CreateCoroutineExecutor();
    }

    private static void CreateCoroutineExecutor()
    {
        if (_coroutineObj != null)
        {
            UnityEngine.Object.Destroy(_coroutineObj);
        }

        _coroutineObj = new GameObject("CoroutineObj");
        UnityEngine.Object.DontDestroyOnLoad(_coroutineObj);
        _coroutineExecutor = _coroutineObj.AddComponent<CoroutineExecutor>();
    }

    private static void EnsureCoroutineExecutor()
    {
        if (_coroutineExecutor == null)
        {
            CreateCoroutineExecutor();
        }
    }

    #region WaitforSeconds

    public static void CallWaitForSeconds(float seconds, Action afterAction)
    {
        EnsureCoroutineExecutor();
        _coroutineExecutor.StartCoroutine(DoCallWaitForSeconds(seconds, afterAction));
    }

    private static IEnumerator DoCallWaitForSeconds(float seconds, Action afterAction)
    {
        yield return new WaitForSeconds(seconds);
        afterAction?.Invoke();
    }

    #endregion

    private class CoroutineExecutor : MonoBehaviour { }
}