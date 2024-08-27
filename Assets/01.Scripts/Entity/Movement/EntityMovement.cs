using UnityEngine;

public abstract class EntityMovement : MonoBehaviour
{
    protected Rigidbody _rigidbodyCompo;

    public bool IsMove => Direction != Vector2.zero;

    public Vector2 Direction { get; private set; }
    public float XInput      { get; private set; }
    public float ZInput      { get; private set; }

    public void SetDirection(Vector2 direction)
    {
        XInput = direction.x;
        ZInput = direction.y;

        Direction = direction;
    }

    public virtual void Movement(float speed)
    {
        if (!IsMove) return;
        
        float y = _rigidbodyCompo.velocity.y;
        
        _rigidbodyCompo.velocity = new Vector3(XInput * speed, y, ZInput * speed);
    }

    public void StopImmediately()
    {
        Direction = Vector2.zero;
        XInput = 0f;
        ZInput = 0f;

        _rigidbodyCompo.velocity = Vector3.zero;
    }
}
