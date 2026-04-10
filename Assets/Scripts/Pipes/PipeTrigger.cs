using System;
using Interaction;
using Player;
using UnityEngine;

namespace Pipes {
    public class PipeTrigger : MonoBehaviour, Interactable {
        [SerializeField] private PipeLogic pipeLogic;
        public void Activate(PlayerManager playerManager) {
            if (playerManager.TryGetComponent(out GoobertManager goobert)) {}
            pipeLogic.MoveGuy(goobert);
        }

        public GameObject GetGameObject() {
            return gameObject;
        }
    }
}