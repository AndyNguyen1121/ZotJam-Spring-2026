using System;
using Player;
using UnityEngine;

namespace Interaction {
    public class InteractionPopup : MonoBehaviour {
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerInteractionManager player;

        private void OnEnable() {
            player.OnInteractionAvailable += ShowInteractionPopup;
            player.OnInteractionUnavailable += HideInteractionPopup;
        }
        private void OnDisable() {
            player.OnInteractionAvailable -= ShowInteractionPopup;
            player.OnInteractionUnavailable -= HideInteractionPopup;
        }
        
        private void ShowInteractionPopup() {
            animator.SetBool("Open", true);
        }

        private void HideInteractionPopup() {
            animator.SetBool("Open", false);
        }
    }
}