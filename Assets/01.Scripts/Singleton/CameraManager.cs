using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    private CommondModeCamera _commodModeCamera;
    public static  CommondModeCamera CommondCamera
    {
        get
        {
            return _instance._commodModeCamera;
        }
    }

    public static void GetComponent_CommonCamera(CommondModeCamera commodModeCamera)
    {
        _instance._commodModeCamera = commodModeCamera;
    }
}