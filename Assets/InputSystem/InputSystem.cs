using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputSystem : ScriptableObject, PlayerInput.IPlayerActionsActions
{
    protected PlayerInput _playerInput;

    private void OnEnable()
    {
        if (_playerInput == null)
        {
            _playerInput = new PlayerInput();
            _playerInput.PlayerActions.SetCallbacks(this);
        }

        _playerInput.PlayerActions.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 movePos = context.ReadValue<Vector2>();
            PlayerHub.OnMoveEvent?.Invoke(movePos);
        }
        else if (context.canceled)
        {
            PlayerHub.OnMoveEvent?.Invoke(Vector2.zero);
        }
    }

    public void OnTransform(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PlayerHub.OnTransformEvent?.Invoke();
        }
    }

    public void OnLeftMouse(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            PlayerHub.OnLeftMouseDownEvent?.Invoke();
        }

        if(context.canceled)
        {
            PlayerHub.OnLeftMouseUpEvent?.Invoke();
        }
    }

    public void On_1(InputAction.CallbackContext context)
    {
    }

    public void On_2(InputAction.CallbackContext context)
    {
    }

    public void On_3(InputAction.CallbackContext context)
    {
    }
}