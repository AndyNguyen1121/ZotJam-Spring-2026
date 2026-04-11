using Interaction;
using Player;
using UnityEngine;
using UnityEngine.Events;

namespace PuzzleObjects {
    public class Button : MonoBehaviour, Interactable {
        [SerializeField] private UnityEvent onInteraction;
        public void Activate(PlayerManager playerManager) {
            onInteraction?.Invoke();
        }

        public GameObject GetGameObject() {
            return gameObject;
        }
    }
}