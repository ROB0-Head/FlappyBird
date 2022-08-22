using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _tapForce = 10;
    [SerializeField] private int _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField]private Vector3 _startPosition;
    
    private Rigidbody2D _rigidbody;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        ResetBird();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.velocity = new Vector2(_speed, 0);
            transform.rotation = _maxRotation;
            _rigidbody.AddForce(Vector2.up * _tapForce,ForceMode2D.Force);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation,_minRotation,_rotationSpeed * Time.deltaTime);
    }

    public void ResetBird()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0,0,0);
        _rigidbody.velocity = Vector2.zero;
    }
}
