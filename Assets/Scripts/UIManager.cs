using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private CoinCounter _coinCounter;
        [SerializeField] private LevelCounter _levelCounter;
        [SerializeField] private TextMeshProUGUI _coinsTxt;
        [SerializeField] private TextMeshProUGUI _levelTxt;

        private void UpdateCoins(int amount)
        {
            _coinsTxt.text = "Coins: " + amount;
        }
        
        private void UpdateLevel(int amount)
        {
            _levelTxt.text = "" + amount;
        }

        private void Start()
        {
            UpdateCoins(_coinCounter.Coins);
            UpdateLevel(_levelCounter.Level);
        }

        private void OnEnable()
        {
            _coinCounter.CoinsUpdated += UpdateCoins;
            _levelCounter.LevelUpdated += UpdateLevel;
        }

        private void OnDisable()
        {
            _coinCounter.CoinsUpdated -= UpdateCoins;
            _levelCounter.LevelUpdated -= UpdateLevel;
        }
    }
}