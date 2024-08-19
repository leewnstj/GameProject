using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputSystem : ScriptableObject, PlayerInput.IPlayerActionsActions
{
    public event Action<Vector2> OnMoveEvent      = null;

    public event Action          OnTransformEvent = null;

    public event Action          OnLeftMouseDownEvent = null;
    public event Action          OnLeftMouseUpEvent = null;

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

    public void OnLeftMouse(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            OnLeftMouseDownEvent?.Invoke();
        }

        if(context.canceled)
        {
            OnLeftMouseUpEvent?.Invoke();
        }
    }
}