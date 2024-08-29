using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRobotTransformCamera : MonoBehaviour
{
    private void OnEnable()
    {
        SignalHub.OnChangedRobotFormEvent += ChangeCamera;
    }

    private void OnDisable()
    {
        SignalHub.OnChangedRobotFormEvent -= ChangeCamera;
    }

    private void ChangeCamera(bool robotForm)
    {
        if(!robotForm)
        {
            CameraManager.CommondCamera.SetCamera(transform);
        }
        else
        {
            CameraManager.CommondCamera.DisableCamera();
        }
    }
}
