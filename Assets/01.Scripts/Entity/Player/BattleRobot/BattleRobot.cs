using UnityEngine;

public class BattleRobot : Player
{
    [Header("Battle Robot")]

    [SerializeField] private Transform _droneTarget;
    public Transform DroneTarget => _droneTarget;

    private void Start()
    {
        StateMachine.Init(EntityStateEnum.Open);
    }
}