#region Input

//마우스 인풋
using UnityEngine;

public delegate void LeftMouseDownEvent();
public delegate void LeftMouseUpEvent();

//로봇 변환
public delegate void TransformEvent();

//이동 인풋
public delegate void MoveEvent(Vector2 movePos);

public delegate void ChangeWeaponEvent(WeaponType type);

#endregion

public static class PlayerHub
{
    public static LeftMouseDownEvent OnLeftMouseDownEvent;
    public static LeftMouseUpEvent OnLeftMouseUpEvent;

    public static TransformEvent OnTransformEvent;

    public static MoveEvent OnMoveEvent;

    public static ChangeWeaponEvent OnChangedWeaponEvent;
}