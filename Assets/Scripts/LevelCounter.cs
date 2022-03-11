using System;
using UnityEngine;
namespace DefaultNamespace
{
    public class LevelCounter : MonoBehaviour
    {
        public Action<int> LevelUpdated;
        public int Level { get; private set; } = 1;

        private void Awake()
        {
            Level = PlayerPrefs.GetInt("level", 1);
        }

        public void Add(int amount)
        {
            Level += amount;
            PlayerPrefs.SetInt("level", Level);
            LevelUpdated?.Invoke(Level);
        }
    }
}