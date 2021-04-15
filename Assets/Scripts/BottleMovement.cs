using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleMovement : MonoBehaviour
{
    [SerializeField] private float _bottleMovementSpeed = 1.0f;

    private void ProcessMovement(float deltaTime)
    {
        transform.position =
            transform.position + new Vector3(_bottleMovementSpeed * deltaTime, 0, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        ProcessMovement(Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        _bottleMovementSpeed = -_bottleMovementSpeed;
    }
}
