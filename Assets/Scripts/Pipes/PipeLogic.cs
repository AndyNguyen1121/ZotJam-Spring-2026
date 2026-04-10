using System;
using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.Splines;

namespace Pipes {
    public class PipeLogic : MonoBehaviour {
        [SerializeField] private float moveSpeed = 5f;

        private SplineContainer _spline;

        private void Awake() {
            _spline = GetComponent<SplineContainer>();
        }

        public void MoveGuy(GoobertManager goobert) {
            StartCoroutine(MoveGuyInternal(goobert));
        }

        private IEnumerator MoveGuyInternal(GoobertManager goobert) {
            Debug.Log("starting");
            PlayerInputManager playerManager = goobert.GetComponent<PlayerInputManager>();
            playerManager.BlockInput(this);
            SplineAnimate animator = goobert.gameObject.AddComponent<SplineAnimate>();
            animator.Container = _spline;
            animator.Easing = SplineAnimate.EasingMode.EaseOut;
            animator.Loop = SplineAnimate.LoopMode.Once;
            animator.AnimationMethod = SplineAnimate.Method.Speed;
            animator.MaxSpeed = moveSpeed;
            animator.Play();
            yield return new WaitUntil(() => !animator.IsPlaying);
            Debug.Log("done");
            playerManager.UnblockInput(this);
        }
    }
}