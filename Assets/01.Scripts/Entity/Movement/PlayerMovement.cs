using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : EntityMovement, IEventPublisher
{
    public void SubscribeEvent()
    {
        InputManager.OnMoveEvent += SetDirection;
    }

    public void UnSubscribeEvent()
    {
        InputManager.OnMoveEvent -= SetDirection;
    }
}