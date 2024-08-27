using ComponentPattern;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : EntityMovement, IEntityComponent
{
    [SerializeField] private UnityEvent OnMoveEvent = null;
    [SerializeField] private UnityEvent OnMoveEndEvent = null;

    public void Init(Entity component)
    {
        _rigidbodyCompo = component.RigidbodyCompo;
    }

    private void OnEnable()
    {
        InputManager.OnMoveEvent += SetDirection;
    }

    private void OnDisable()
    {
        InputManager.OnMoveEvent -= SetDirection;
    }

    public override void Movement(float speed)
    {
        base.Movement(speed);

        if(Direction != Vector2.zero)
            OnMoveEvent?.Invoke();
        else
            OnMoveEndEvent?.Invoke();
    }
}