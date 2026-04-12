using System;
using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.Splines;

namespace Pipes {
    public class PipeLogic : MonoBehaviour {
        [SerializeField] private float moveGoobertTime = 1f;
        [SerializeField] private float moveSpeed = 5f;
        private bool isReversed = false;

        private SplineContainer _spline;

        private void Awake() {
            _spline = GetComponent<SplineContainer>();
        }

        public void MoveGuy(GoobertManager goobert, bool startAtBeginning = true) {
            StartCoroutine(MoveGuyInternal(goobert, startAtBeginning));
        }

        private IEnumerator MoveGuyInternal(GoobertManager goobert, bool startAtBeginning = true) {
            SplineAnimate animator = goobert.gameObject.AddComponent<SplineAnimate>();
            animator.Container = _spline;
            animator.Easing = SplineAnimate.EasingMode.EaseInOut;
            animator.Loop = SplineAnimate.LoopMode.Once;
            animator.AnimationMethod = SplineAnimate.Method.Speed;
            animator.MaxSpeed = moveSpeed;
            goobert.EnterPipe();
            
            if (isReversed && startAtBeginning)
            {
                isReversed = false;
                animator.Container.ReverseFlow(0);
            }
            else if (!isReversed && !startAtBeginning)
            {
                isReversed = true;
                animator.Container.ReverseFlow(0);
            }

            yield return MoveGoobertTo(goobert, animator, startAtBeginning);
            animator.Play();
            
            yield return new WaitUntil(() => !animator.IsPlaying);
            goobert.ExitPipe();
        }

        private IEnumerator MoveGoobertTo(GoobertManager goobert, SplineAnimate animator, bool startAtBeginning = true) {
            Vector3 startPosition = goobert.transform.position;
            Vector3 endPosition = animator.Container.transform.position + (Vector3)animator.Container[0][0].Position;
            
            Quaternion startRotation = goobert.transform.rotation;
            Quaternion endRotation = animator.Container[0][0].Rotation;

            float t = 0;
            float p = 0;
            while (t < moveGoobertTime) {
                t += Time.deltaTime;
                p = t / moveGoobertTime;
                goobert.transform.position = Vector3.Lerp(startPosition, endPosition, p);
                goobert.transform.rotation = Quaternion.Slerp(startRotation, endRotation, p);
                yield return null;
            }
        }
    }
}