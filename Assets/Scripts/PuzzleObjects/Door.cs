using System;
using UnityEngine;

namespace PuzzleObjects {
    public class Door : MonoBehaviour {
        private Animator _animator;

        private void Awake() {
            TryGetComponent(out _animator);
        }

        public void OpenDoor() {
            _animator.SetBool("Open", true);
        }

        public void CloseDoor() {
            _animator.SetBool("Open", false);
        }
    }
}