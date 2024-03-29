﻿using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class FailTrigger : MonoBehaviour
    {
        [SerializeField] private string _playerTag = "Player";
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(_playerTag)) return;
            
            Debug.Log("Fail");
            other.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}