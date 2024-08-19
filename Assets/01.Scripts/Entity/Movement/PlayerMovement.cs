using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : EntityMovement, IEventPublisher
{
    public void SubscribeEvent()
    {
        PlayerHub.OnMoveEvent += SetDirection;
    }

    public void UnSubscribeEvent()
    {
        PlayerHub.OnMoveEvent -= SetDirection;
    }
}