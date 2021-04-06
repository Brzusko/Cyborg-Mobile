using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Gyroscope = UnityEngine.InputSystem.Gyroscope;

public class InputManager : MonoBehaviour
{
    public float HorizontalRotation => _yAxis;

    public static InputManager instance
    {
        get
        {
            if (!_instance) throw new NullReferenceException();
            return _instance;
        }
    }
    private float _yAxis = 0.0f;
    private static InputManager _instance = null;
    private void SwitchGyroState(bool state)
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = state;
        }
    }

    private Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (!SystemInfo.supportsGyroscope) return;
        var attitudeEuler = GyroToUnity(Input.gyro.attitude).eulerAngles;
        _yAxis = attitudeEuler.y;
    }

    private void OnEnable()
    {
        SwitchGyroState(true);
    }

    private void OnDisable()
    {
        SwitchGyroState(false);
    }
}
