using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class SimpleCoin : MonoBehaviour
    {
        [SerializeField] private string _playerTag = "Player";
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_playerTag))
            {
                Destroy(gameObject);
            }
        }
    }
}