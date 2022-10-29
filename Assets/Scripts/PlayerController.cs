using System;
using UnityEngine;

public class PlayerController : PersonScript
{

    private MoveController _controller;
    
    private bool _canJump;
    
    void Awake()
    {
        _controller = new MoveController();
        _controller.Player.Jump.performed += _ => Jump();
    }

    void FixedUpdate()
    {
        var direction = _controller.Player.PersonMove.ReadValue<float>();
        if (direction == 0f) return;

        _rigidbody.velocity = direction * Time.fixedDeltaTime * transform.right * _speed;

    }

    private void OnEnable()
    {
        _controller.Player.Enable();
    }

    private void OnDisable()
    {
        _controller.Player.Disable();
    }

    private void OnDestroy()
    {
        _controller.Dispose();
    }

    private void Jump()
    {
        if (!_canJump) return;
        _canJump = false;
        _rigidbody.AddForce(transform.up * _force);
    }

    private void OnCollisionEnter(Collision other)
    {
        _canJump = true;
    }
}
