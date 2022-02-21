using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CoinCounter : MonoBehaviour
    {
        public Action<int> CoinsUpdated;

        private void Start()
        {
            _coins = PlayerPrefs.GetInt("coins", 0);
        }

        private void OnDisable()
        {
            PlayerPrefs.SetInt("coins", _coins);
        }


        public void Add(int amount)
        {
            _coins += amount;
            CoinsUpdated?.Invoke(_coins);
            Debug.Log("Coins count: "+_coins);
        }

        private int _coins = 0;
    }
}