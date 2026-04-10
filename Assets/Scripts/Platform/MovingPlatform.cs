using System;
using UnityEngine;

namespace Platform
{
    public class MovingPlatform : MonoBehaviour
    {
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
    }
}