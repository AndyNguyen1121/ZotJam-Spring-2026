using NUnit.Framework.Constraints;
using UnityEngine;

public class ConditionalPressurePlate : MonoBehaviour
{
    [HideInInspector]
    public bool isPressed = false;

    void OnTriggerEnter(Collider other)
    {
        isPressed = true;
    }

    void OnTriggerExit(Collider other)
    {
        isPressed = false;
    }
}
