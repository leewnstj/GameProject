public enum EntityStateEnum
{
    #region Entity

    Idle,
    Walk,

    #endregion

    #region BattleRobot

    Open,
    ChangeRoll,
    Roll,
    StopRoll,
    Close,
    Ball

    #endregion
}

public enum EntityType
{
    None = 0,
    BattleRobot,
    Robot,
    Enemy
}