using System;
using UnityEngine;
using UnityEngine.Events;

public class ConditionalPressurePlateDetector : MonoBehaviour
{
    public ConditionalPressurePlate[] pressurePlates;

    public bool keepOpen = false;

    [SerializeField] private UnityEvent pressed;
    [SerializeField] private UnityEvent unpressed;

    private bool _lastFramePressed = true;
    
    [System.Serializable]
    public class MoveableObject
    {
        public Transform target;
        public Vector3 targetPosition;
        
        [HideInInspector] public Vector3 startPosition;
    }
    
    // public MoveableObject[] objectsToMove;
    
    private float progress = 0f; // start = 0 end = 1

    void Start()
    {
        // foreach (var moveableObject in objectsToMove)
        // {
            // moveableObject.startPosition = moveableObject.target.position;
        // }
    }

    private void Update()
    {
        bool allPlatesPressed = true;
        foreach (ConditionalPressurePlate p in pressurePlates)
        {
            if (!p.isPressed)
            {
                allPlatesPressed = false;
                break;
            }
        }
        
        if (allPlatesPressed && !_lastFramePressed) {
            pressed?.Invoke();
        }
        if (_lastFramePressed && !allPlatesPressed) {
            unpressed?.Invoke();
        }
        
        _lastFramePressed = allPlatesPressed;
    }
    // private void moveObjects(float direction)
    // {
    //     progress += direction * 1f * Time.deltaTime;
    //     progress = Mathf.Clamp01(progress);
    //     
    //     float t = Mathf.SmoothStep(0f, 1f, progress);
    //     
    //     foreach(var obj in objectsToMove)
    //     {
    //         obj.target.position = 
    //             Vector3.Lerp(obj.startPosition, obj.targetPosition, t);
    //     }
    // }
}
