using System;
using Player;
using UnityEngine;

namespace Interaction {
    public class InteractionPopup : MonoBehaviour {
        [SerializeField] private PlayerInteractionManager player;

        private Animator _animator;
        
        private void Awake() {
            TryGetComponent(out _animator);
        }

        private void OnEnable() {
            player.OnInteractionAvailable += ShowInteractionPopup;
            player.OnInteractionUnavailable += HideInteractionPopup;
        }
        private void OnDisable() {
            player.OnInteractionAvailable -= ShowInteractionPopup;
            player.OnInteractionUnavailable -= HideInteractionPopup;
        }
        
        private void ShowInteractionPopup() {
            _animator.SetBool("Visible", true);
        }

        private void HideInteractionPopup() {
            _animator.SetBool("Visible", false);
        }
    }
}