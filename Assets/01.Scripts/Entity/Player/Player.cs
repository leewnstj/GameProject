public class Player : Entity
{
    public bool IsMove => PlayerMovementCompo.IsMove;

    public BattleRobotSO RobotSO   { get; private set; }

    public  PlayerMovement PlayerMovementCompo { get; private set; }
    private RobotRotation  RobotRotateCompo;
    private ChangeWeapon   ChangedWeaponCompo;

    protected override void Awake()
    {
        base.Awake();

        RobotRotateCompo    = new(transform);
        ChangedWeaponCompo  = new(PlanetManager.WeaponRegister.WeaponSelectList, _robotSO.TransformCoolTime);
        PlayerMovementCompo = new(RigidbodyCompo);

        RobotSO = Instantiate(_robotSO);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        RobotRotateCompo.RotateTowardsMouse(_robotSO.RotateSpeed);
    }

    public void SetRotation(bool value) => RobotRotateCompo.SetRotation(value);

    protected override void SubscribeFunction()
    {
        InputManager.OnNumberInputEvent += ChangedWeaponCompo.WeaponChange;
        InputManager.OnMoveEvent        += PlayerMovementCompo.SetDirection;
    }

    protected override void UnsubscribeFunction()
    {
        InputManager.OnNumberInputEvent -= ChangedWeaponCompo.WeaponChange;
        InputManager.OnMoveEvent        -= PlayerMovementCompo.SetDirection;
    }
}