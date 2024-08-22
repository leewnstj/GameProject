using UnityEngine;
using UnityEngine.InputSystem;

public delegate void TransformEvent();
public delegate void MoveEvent(Vector2 direction);

public partial class InputManager
{
    public static MoveEvent OnMoveEvent;
    public static TransformEvent OnTransformEvent;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 movePos = context.ReadValue<Vector2>();
            OnMoveEvent?.Invoke(movePos);
        }
        else if (context.canceled)
        {
            OnMoveEvent?.Invoke(Vector2.zero);
        }
    }

    public void OnTransform(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnTransformEvent?.Invoke();
        }
    }
}