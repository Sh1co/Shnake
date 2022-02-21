using UnityEngine;

namespace DefaultNamespace
{
    public class FinishTrigger : MonoBehaviour
    {
        [SerializeField] private string _playerTag = "Player";
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(_playerTag)) return;
            
            Debug.Log("Finish");
            other.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}