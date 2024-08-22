using UnityEngine.InputSystem;

public delegate void NumberInputEvent(int number);

public partial class InputManager
{
    public static NumberInputEvent OnNumberInputEvent;

    public void On_1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnNumberInputEvent?.Invoke(0);
        }
    }

    public void On_2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnNumberInputEvent?.Invoke(1);
        }
    }

    public void On_3(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnNumberInputEvent?.Invoke(2);
        }
    }
}