using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 1.0f;
    [SerializeField] private Vector3 Direction1 = Vector3.forward;
    [SerializeField] private Vector3 Direction2 = Vector3.left;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _directionIndex = _directionIndex == 0 ? 1 : 0;
        }

        /*if (Input.touchCount <= 0) return;
        var touch = Input.touches[0];
        if (touch.phase == TouchPhase.Began)
        {
            _directionIndex = _directionIndex == 0 ? 1 : 0;
        }*/
    }

    private void FixedUpdate()
    {
        Vector3 velocity = GetDirection() * _playerSpeed;
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }

    private Vector3 GetDirection()
    {
        return _directionIndex == 0 ? Direction1 : Direction2;
    }

    private void OnDisable()
    {
        Vector3 velocity = Vector3.zero;
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }

    public void ResetPosition()
    {
        transform.position = Vector3.zero;
        _directionIndex = 0;

    }
    
    private int _directionIndex = 0;
    private Rigidbody _rigidbody;
}
