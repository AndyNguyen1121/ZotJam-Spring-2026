using System;
using Interaction;
using Player;
using UnityEngine;

namespace Pipes {
    
    public class PipeTrigger : MonoBehaviour, Interactable {
        [SerializeField] private PipeLogic pipeLogic;
        public bool startAtBeginning = true;
        public void Activate(PlayerManager playerManager)
        {
            if (!CanInteract(playerManager))
                return;
            
            if (playerManager.TryGetComponent(out GoobertManager goobert)) {}
            pipeLogic.MoveGuy(goobert, startAtBeginning);
        }

        public GameObject GetGameObject() {
            return gameObject;
        }

        public bool CanInteract(PlayerManager playerManager)
        {
            return playerManager is GoobertManager;
        }
    }
}