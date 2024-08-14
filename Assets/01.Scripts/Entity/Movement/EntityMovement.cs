using UnityEngine;

public class EntityMovement
{
    private Rigidbody _rigidbodyCompo;
    private float _friction;

    public EntityMovement(Rigidbody rigidbody, float friction = 0.95f)
    {
        _rigidbodyCompo = rigidbody;
        _friction = friction;
    }

    public bool IsMove => Direction != Vector2.zero;

    public Vector2 Direction { get; private set; }
    public float XInput { get; private set; }
    public float ZInput { get; private set; }

    public void SetDirection(Vector2 direction)
    {
        XInput = direction.x;
        ZInput = direction.y;

        Direction = direction;
    }

    public void Movement(float speed, bool isSliding = false)
    {
        if (IsMove)
        {
            float y = _rigidbodyCompo.velocity.y;
            _rigidbodyCompo.velocity = new Vector3(XInput * speed, y, ZInput * speed);
        }
        else if(isSliding && !IsMove)
        {
            ApplySliding();
        }
    }

    public void StopImmediately()
    {
        Direction = Vector2.zero;
        XInput = 0f;
        ZInput = 0f;

        _rigidbodyCompo.velocity = Vector3.zero;
    }

    private void ApplySliding()
    {
        Vector3 velocity = _rigidbodyCompo.velocity;
        velocity.x *= _friction;
        velocity.z *= _friction;

        if (velocity.magnitude < 0.1f)
        {
            velocity.x = 0f;
            velocity.z = 0f;
        }

        _rigidbodyCompo.velocity = velocity;
    }
}
