using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour
{
    [System.Serializable]
    public class MoveableObject
    {
        public Transform target;
        public Vector3 targetPosition;
        
        [HideInInspector] public Vector3 startPosition;
    }
    
    public MoveableObject[] objectsToMove;
    
    private int objectsOnPlate = 0;
    private float progress = 0f; // start = 0 end = 1

    void Start()
    {
        foreach (var moveableObject in objectsToMove)
        {
            moveableObject.startPosition = moveableObject.target.position;
        }
    }

    void Update()
    {
        float direction = objectsOnPlate > 0 ? 1f : -1f;
        
        // 1f moveSpeed
        progress += direction * 1f * Time.deltaTime;
        progress = Mathf.Clamp01(progress);
        
        float t = Mathf.SmoothStep(0f, 1f, progress);
        
        foreach(var obj in objectsToMove)
        {
            obj.target.position = 
                Vector3.Lerp(obj.startPosition, obj.targetPosition, t);
        }
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " entered");
        objectsOnPlate++;
        
    }

    void OnTriggerExit(Collider other)
    {
        objectsOnPlate = Mathf.Max(0, objectsOnPlate - 1);
    }
    
    
    
}
