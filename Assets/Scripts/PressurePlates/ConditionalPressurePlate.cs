using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class ConditionalPressurePlate : MonoBehaviour
{
    public bool isPressed = false;
    public List<GameObject> ObjectOnPlates = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gort" || other.tag == "Goobert" || other.tag == "Crate")
        {
            if (!ObjectOnPlates.Contains(other.gameObject))
            {
                ObjectOnPlates.Add(other.gameObject);
                isPressed = true;
            }
            
        }

        Debug.Log(other.gameObject.name);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gort" || other.tag == "Goobert" || other.tag == "Crate")
        {
            ObjectOnPlates.Remove(other.gameObject);
            if (ObjectOnPlates.Count == 0)
                isPressed = false;
        }
    }
}
