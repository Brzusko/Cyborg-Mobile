using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

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
    private Func<float> _calculateRotation;
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

        if (SystemInfo.supportsGyroscope)
            _calculateRotation = () => Mathf.Deg2Rad * GyroToUnity(Input.gyro.attitude).eulerAngles.y;
        else
            _calculateRotation = () => Input.GetAxis("Horizontal");
    }
    
    private void Update()
    {
        _yAxis = _calculateRotation.Invoke();
    }

    private void OnEnable()
    {
        SwitchGyroState(true);
    }

    private void OnDisable()
    {
        SwitchGyroState(false);
    }

    private static void Clear() => InputManager._instance = null;
    public void DestroyManager() {
        Clear();
        Destroy(this);
    }
}
