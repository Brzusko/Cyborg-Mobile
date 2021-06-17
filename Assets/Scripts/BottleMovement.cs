using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleMovement : MonoBehaviour
{
    [SerializeField] private float _bottleMovementSpeed = 1.0f;
    [SerializeField] private int _startingPoint = 20;
    private int _reverse = 1;
    public int gameOver = 1;

    private void ProcessMovement(float deltaTime)
    {
        transform.position =
            transform.position + new Vector3(_bottleMovementSpeed * deltaTime, 0, transform.position.z);
    }

    public void Restart(){
        this._reverse = 1;
        this.gameOver = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _bottleMovementSpeed = gameOver*_reverse*((DifficultyLevel.time/DifficultyLevel.difficultyLevel)-DifficultyLevel.minLevel-DifficultyLevel.difficultyLevel+_startingPoint)*DifficultyLevel.scale;
        ProcessMovement(Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        _reverse = -_reverse;
    }
}
