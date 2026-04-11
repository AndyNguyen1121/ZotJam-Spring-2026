using System;
using UnityEngine;
using UnityEngine.Splines;

namespace Platform
{
    public class MovingPlatform : MonoBehaviour
    {
        public SplineAnimate splineAnimator;    
        private void Awake()
        {
            splineAnimator = GetComponent<SplineAnimate>();
            splineAnimator.Completed += () => splineAnimator.Pause();
            splineAnimator.Pause();
            splineAnimator.PlayOnAwake = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Gort") || other.CompareTag("Goobert") || other.CompareTag("Crate"))
            {
                if (other.CompareTag("Goobert"))
                {
                    GoobertManager goobertManager = other.gameObject.GetComponent<GoobertManager>();
                    if (goobertManager != null)
                    {
                        if (goobertManager.isOnGort)
                            return;
                    }
                }
                other.transform.SetParent(transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Gort") || other.CompareTag("Goobert") || other.CompareTag("Crate"))
            {
                if (other.CompareTag("Goobert"))
                {
                    GoobertManager goobertManager = other.gameObject.GetComponent<GoobertManager>();
                    if (goobertManager != null)
                    {
                        if (goobertManager.isOnGort)
                            return;
                    }
                }
                other.transform.SetParent(null);
            }
        }

        public void ActivatePlatform()
        {
            if (splineAnimator != null && !splineAnimator.IsPlaying)
            { 
                splineAnimator.Play();
            }
        }
    }
}