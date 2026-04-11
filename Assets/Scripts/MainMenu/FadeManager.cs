using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu {
    public class FadeManager : MonoBehaviour {
        [SerializeField] private Image blackout;
        [SerializeField] public float blackoutTime = 1f;
        [SerializeField] private float waitTime = 1f;

        public static FadeManager Instance;
        
        private float _currentFade = 0f;

        private void Awake() {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            } else {
                Destroy(gameObject);
            }
        }

        public void FadeToBlack() {
            StopAllCoroutines();
            StartCoroutine(FadeToBlackRoutine());
        }
        
        public void FadeFromBlack() {
            StopAllCoroutines();
            StartCoroutine(FadeFromBlackRoutine());
        }

        private IEnumerator FadeToBlackRoutine() {
            float start = _currentFade;
            float end = 1f;
            float t = 0f;

            while (t < blackoutTime) {
                t += Time.deltaTime;
                blackout.color = new Color(blackout.color.r, blackout.color.g, blackout.color.b,
                    Mathf.Lerp(start, end, t));
                yield return null;
            }
            _currentFade = end;
            blackout.color = Color.black;
        }
        
        private IEnumerator FadeFromBlackRoutine() {
            float start = _currentFade;
            float end = 0f;
            float t = 0f;
            
            blackout.color = new Color(blackout.color.r, blackout.color.g, blackout.color.b,
                _currentFade);
            
            yield return new WaitForSeconds(waitTime);

            while (t < blackoutTime) {
                t += Time.deltaTime;
                _currentFade = Mathf.Lerp(start, end, t);
                blackout.color = new Color(blackout.color.r, blackout.color.g, blackout.color.b,
                    _currentFade);
                yield return null;
            }
            _currentFade = end;
            blackout.color = Color.clear;
        }
    }
}