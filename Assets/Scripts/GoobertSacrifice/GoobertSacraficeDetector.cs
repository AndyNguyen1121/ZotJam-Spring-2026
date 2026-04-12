using System;
using UnityEngine;
using UnityEngine.Events;

public class GoobertSacraficeDetector : MonoBehaviour
{
    public GoobertSacrifice.GoobertSacrifice circuit;
    
    [SerializeField] private UnityEvent pressed;
    [SerializeField] private UnityEvent unpressed;

    private void Update()
    {
        if (circuit.isPressed)
        {
            pressed?.Invoke();
        }
        else
        {
            unpressed?.Invoke();
        }
    }
}
