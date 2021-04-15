using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperParticle : MonoBehaviour
{
    [SerializeField] private float _defaultGravityScale = 0.0f;
    private float _currentGravityScale = 0.0f;

    private Rigidbody2D _rigidbody2D = null;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Active(Vector3 position)
    {
        _rigidbody2D.gravityScale = _defaultGravityScale;
        _rigidbody2D.velocity = Vector3.zero;
        _rigidbody2D.angularVelocity = 0;
        transform.position = position;
    }

    public void Disactive(Vector3 position)
    {
        _rigidbody2D.gravityScale = 0.0f;
        transform.position = position;
    }
}
