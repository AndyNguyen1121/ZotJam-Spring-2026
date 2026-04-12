using System;
using Interaction;
using UnityEngine;

namespace Player {
    public class PlayerInteractionManager : MonoBehaviour {
        [SerializeField] private float interactionRadius = 1;
        [SerializeField] private LayerMask interactableLayer;
        [Header("Links")]
        [SerializeField] private PlayerInputManager playerInputManager;

        [SerializeField] private PlayerManager playerManager;


        private Interactable _currentInteractable;

        public event Action OnInteractionAvailable;
        public event Action OnInteractionUnavailable;


        private void OnEnable() {
            playerInputManager.OnInteract += TryInteract;
        }
        private void OnDisable() {
            playerInputManager.OnInteract -= TryInteract;
        }
        
        private void Update() {
            CheckForInteractions();
        }

        private void CheckForInteractions() {
            Collider[] results = new Collider[5];
            int size = Physics.OverlapSphereNonAlloc(transform.position, interactionRadius, results, interactableLayer);

            if (size > 0) {
                if ((_currentInteractable == null || results[0].gameObject != _currentInteractable.GetGameObject())) {
                    _currentInteractable = results[0].GetComponent<Interactable>();
                    
                    if (_currentInteractable.CanInteract(playerManager))
                        OnInteractionAvailable?.Invoke();
                }
            } 
            else {
                if (_currentInteractable != null || (_currentInteractable != null && !_currentInteractable.CanInteract(playerManager))) {
                    OnInteractionUnavailable?.Invoke();
                    _currentInteractable = null;
                }
            }
            
            if (size > 1) {
                // Debug.LogWarning("Multiple interactables in range, choosing the first one");
            }
        }
        
        private void TryInteract() {
            if (_currentInteractable == null) return;

            _currentInteractable.Activate(playerManager);
        }
    }
}