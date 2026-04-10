using System;
using Player;
using UnityEngine;

namespace Pipes {
    public class PipeTrigger : MonoBehaviour {
        [SerializeField] private PipeLogic pipeLogic;
        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Goobert") && other.TryGetComponent(out GoobertManager goobert)) {
                pipeLogic.MoveGuy(goobert);
            }
        }
    }
}