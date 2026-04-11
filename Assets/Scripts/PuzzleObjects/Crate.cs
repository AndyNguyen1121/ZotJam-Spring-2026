using System;
using UnityEngine;

namespace PuzzleObjects {
    public class Crate : MonoBehaviour {
        private Vector3 _startPos;
        
        private void Awake() {
            _startPos = transform.position;
        }

        public void ResetPosition() {
            transform.position = _startPos;
        }
    }
}