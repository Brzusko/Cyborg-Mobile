using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _slideSpeed = 0.01f;
    private float _acceleration = 0.0f;
    private InputManager _inputManager;
    private Transform _transform = null;
    private Rigidbody2D _rigidbody2D = null;

    [SerializeField]
    private SpriteRenderer _head = null;

    [SerializeField]
    private SpriteRenderer _body = null;

    [SerializeField]
    private SpriteRenderer _tire = null;

    [SerializeField]
    private Animator _animator = null;
    private Action<float> _calcAcceleration;
    
    private void ProcessMovement(float deltaTime)
    {
        transform.localScale = _acceleration < 0 ? new Vector2(-5.0f, 5.0f) : new Vector2(5.0f, 5.0f);
        _rigidbody2D.velocity = new Vector2(_acceleration * _slideSpeed * deltaTime, 0.0f);
        _animator.SetBool("isMoving", _acceleration != 0);
    }
    void Start()
    {
        _inputManager = InputManager.instance;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (Input.gyro.enabled)
            _calcAcceleration = deltaTime =>
            {
                var phoneRotation = _inputManager.HorizontalRotation;
                if (phoneRotation <= 180)
                {
                    _acceleration = 1.0f;
                }
                else
                {
                    _acceleration = -1.0f;
                }
            };
        else
            _calcAcceleration = deltaTime => _acceleration = _inputManager.HorizontalRotation;
    }
    
    void Update()
    {
        _calcAcceleration(Time.deltaTime);
    }

    public void OnStartMovingAnim() {
        _animator.SetFloat("MovingSpeed", 0.0f);
    }

    private void FixedUpdate()
    {
        ProcessMovement(Time.deltaTime);
    }
}
