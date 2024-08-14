using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Robot))]
public class RobotMouseHandler : MonoBehaviour
{
    private Robot _owner;
    private InputSystem _inputReader => _owner.InputSystem;

    private void Awake()
    {
        _owner = GetComponent<Robot>();
    }

    private void OnEnable()
    {
        _inputReader.OnLeftMouseDownEvent += OnLeftMouseDown;
        _inputReader.OnLeftMouseUpEvent += OnLeftMouseUp;
    }

    private void OnDisable()
    {
        _inputReader.OnLeftMouseDownEvent -= OnLeftMouseDown;
        _inputReader.OnLeftMouseUpEvent -= OnLeftMouseUp;
    }

    public UnityEvent OnLeftMouseDownEvent = null;
    public UnityEvent OnLeftMouseUpEvent   = null;

    public void OnLeftMouseDown()
    {
        OnLeftMouseDownEvent?.Invoke();
    }

    public void OnLeftMouseUp()
    {
        OnLeftMouseUpEvent?.Invoke();
    }
}