using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EntityMovement : MonoBehaviour
{
    private Rigidbody _rigidbodyCompo;

    public bool IsMove => Direction != Vector2.zero;

    public Vector2 Direction { get; private set; }
    public float XInput { get; private set; }
    public float ZInput { get; private set; }


    private void Awake()
    {
        _rigidbodyCompo = GetComponent<Rigidbody>();
    }

    public void SetDirection(Vector2 direction)
    {
        XInput = direction.x;
        ZInput = direction.y;

        Direction = direction;
    }

    public void Movement(float speed)
    {
        float y = _rigidbodyCompo.velocity.y;

        _rigidbodyCompo.velocity = new Vector3(XInput * speed, y, ZInput * speed);
    }

    public void StopImmediately()
    {
        Direction = Vector2.zero;
        XInput = 0f;
        ZInput = 0f;
    }
}