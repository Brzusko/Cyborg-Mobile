using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    [SerializeField] private float _defaultGravityScale = 0.0f;
    private float _currentGravityScale = 0.0f;

    private Rigidbody2D _rigidbody2D = null;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    public void Active(Vector3 position)
    {
        _rigidbody2D.gravityScale = _defaultGravityScale;
        transform.position = position;
    }

    public void Disactive(Vector3 position)
    {
        _rigidbody2D.gravityScale = 0.0f;
        transform.position = position;
    }
}
