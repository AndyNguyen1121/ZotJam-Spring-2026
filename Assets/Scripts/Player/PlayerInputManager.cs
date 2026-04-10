using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Object = System.Object;

namespace Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        [Header("Assign in Inspector")] [SerializeField]
        private PlayerInput PlayerInput;

        [Header("Input Info")]
        public float sensitivity;
        [SerializeField] private Vector2 movementInput;
        [SerializeField] private Vector2 mouseInput;
        [SerializeField] private bool isSprinting;
        public Vector2 MovementInput => movementInput;
        public Vector2 MouseInput => mouseInput;
        public bool IsSprinting => isSprinting;

        private List<Object> _blockers = new List<Object>();
        
        public bool IsBlocked => _blockers.Count > 0;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


        private void OnEnable()
        {
            PlayerInput.actions["Move"].performed += OnMove;
            PlayerInput.actions["Move"].canceled += OnMoveCanceled;
            PlayerInput.actions["Look"].performed += OnLook;
            PlayerInput.actions["Sprint"].performed += ctx => isSprinting = true;
            PlayerInput.actions["Sprint"].canceled += ctx => isSprinting = false;
        }

        private void OnDisable()
        {
            PlayerInput.actions["Move"].performed -= OnMove;
            PlayerInput.actions["Move"].canceled -= OnMoveCanceled;
            PlayerInput.actions["Look"].performed -= OnLook;
        }

        private void OnMove(InputAction.CallbackContext ctx) {
            if (_blockers.Count > 0) return;
            movementInput = ctx.ReadValue<Vector2>();
        }
        private void OnMoveCanceled(InputAction.CallbackContext ctx)
        {
            movementInput = Vector2.zero;;
        }
        private void OnLook(InputAction.CallbackContext ctx)
        {
            mouseInput = ctx.ReadValue<Vector2>();
        }

        public void BlockInput(Object blocker) {
            _blockers.Add(blocker);
            if (_blockers.Count == 1) {
                OnMoveCanceled(new InputAction.CallbackContext());
            }
        }

        public void UnblockInput(Object blocker) {
            _blockers.Remove(blocker);
        }
    }
}