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

    private void CalcAcceleration(float deltaTime)
    {
        var hRotation = _inputManager.HorizontalRotation;
        if (hRotation <= 3.13f)
        {
            _acceleration = 1.0f;
        }
        else
        {
            _acceleration = -1.0f;
        }
    }

    private void ProcessMovement(float deltaTime)
    {
        transform.position = transform.position + new Vector3(_acceleration * deltaTime * _slideSpeed, 0, transform.position.z);;
    }
    void Start()
    {
        _inputManager = InputManager.instance;
    }
    void Update()
    {
        CalcAcceleration(Time.deltaTime);
        ProcessMovement(Time.deltaTime);
    }
}
