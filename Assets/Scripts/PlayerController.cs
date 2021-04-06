using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum MovementType
    {
        LEFT,
        RIGHT,
        NONE,
    }

    private MovementType _movementType = MovementType.NONE;
    private InputManager _inputManager;
    void Start()
    {
        _inputManager = InputManager.instance;
    }
    void Update()
    {
        Debug.Log(_inputManager.HorizontalRotation.ToString());
    }
}
