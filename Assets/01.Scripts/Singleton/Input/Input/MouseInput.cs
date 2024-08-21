using UnityEngine.InputSystem;

public delegate void LeftMouseEvent();
public delegate void LeftMouseDownEvent();
public delegate void LeftMouseUpEvent();

public partial class InputManager
{
    public static LeftMouseEvent OnLeftMouseEvent;
    public static LeftMouseDownEvent OnLeftMouseDownEvent;
    public static LeftMouseUpEvent OnLeftMouseUpEvent;

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            OnLeftMouseEvent?.Invoke();
        }
    }

    public void OnLeftMouse(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnLeftMouseDownEvent?.Invoke();
        }

        if (context.canceled)
        {
            OnLeftMouseUpEvent?.Invoke();
        }
    }
}