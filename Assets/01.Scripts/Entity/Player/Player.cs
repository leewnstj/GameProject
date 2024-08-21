using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public bool IsMove => PlayerMovementCompo.IsMove;

    public BattleRobotSO RobotSO   { get; private set; }

    public PlayerMovement PlayerMovementCompo { get; private set; }
    public RobotRotation RobotRotateCompo { get; private set; }
    public ChangeWeapon ChangedWeaponCompo { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        RobotRotateCompo = new(transform);

        ChangedWeaponCompo = EventFactoryCompo.CreateEntityComponent<ChangeWeapon>();
        ChangedWeaponCompo.SetInit(_robotSO.TransformCoolTime);

        PlayerMovementCompo = EventFactoryCompo.CreateEntityComponent<PlayerMovement>();
        PlayerMovementCompo.Init(RigidbodyCompo);

        RobotSO = Instantiate(_robotSO);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        RobotRotateCompo.RotateTowardsMouse(_robotSO.RotateSpeed);
    }

    public void SetRotation(bool value) => RobotRotateCompo.SetRotation(value);
}
