using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputSystem : ScriptableObject, PlayerInput.IPlayerActionsActions
{
    public event Action<Vector2> OnMoveEvent      = null;
    public event Action          OnTransformEvent = null;

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
}