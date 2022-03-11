using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CoinCounter : MonoBehaviour
    {
        public Action<int> CoinsUpdated;
        public int Coins { get; private set; } = 0;

        private void Awake()
        {
            Coins = PlayerPrefs.GetInt("coins", 0);
        }

        public void Add(int amount)
        {
            Coins += amount;
            PlayerPrefs.SetInt("coins", Coins);
            CoinsUpdated?.Invoke(Coins);
            Debug.Log("Coins count: "+Coins);
        }
    }
}