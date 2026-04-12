using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Interaction {
    public interface Interactable {
        public void Activate(PlayerManager playerManager);
        public GameObject GetGameObject();
        
        public bool CanInteract(PlayerManager playerManager);
    }
}