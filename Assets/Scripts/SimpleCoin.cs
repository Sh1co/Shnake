using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class SimpleCoin : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}