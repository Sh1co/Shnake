using UnityEngine;

namespace DefaultNamespace
{
    public class FinishTrigger : MonoBehaviour
    {
        [SerializeField] private string _playerTag = "Player";
        public LevelGenerator LevelGenerator;
        public LevelCounter LevelCounter;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(_playerTag)) return;
            other.GetComponent<PlayerMovement>().ResetPosition();
            LevelGenerator.GenerateLevel();
            LevelCounter.Add(1);
        }
    }
}