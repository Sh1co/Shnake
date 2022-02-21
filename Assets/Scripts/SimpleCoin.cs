using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class SimpleCoin : MonoBehaviour
    {
        [SerializeField] private string _playerTag = "Player";
        [SerializeField] private float _movementTime = 1f;
        [SerializeField] private float _movementSpeed = 1f;
        [SerializeField] private float _rotationsSpeed = 1f;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_playerTag))
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Vector3 angularVelocity = new Vector3(0, _rotationsSpeed, 0);
            _rigidbody.angularVelocity = angularVelocity;

            Vector3 velocity = new Vector3(0, _movementSpeed, 0);
            if (!_goingUp) velocity *= -1f;
            _rigidbody.velocity = velocity * (_movementTime - _timer);

            _timer += Time.fixedDeltaTime;
            if (_timer >= _movementTime)
            {
                _timer = 0f;
                _goingUp = !_goingUp;
            }
        }

        private Rigidbody _rigidbody;
        private bool _goingUp = true;
        private float _timer = 0;
    }
}