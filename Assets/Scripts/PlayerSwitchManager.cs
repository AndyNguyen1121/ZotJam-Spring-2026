using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwitchManager : MonoBehaviour
{

    [SerializeField] private PlayerInput goobert_PI;
    [SerializeField] private PlayerInput gort_PI;
    
    [SerializeField] private PlayerMovementManager goobert_MM;
    [SerializeField] private PlayerMovementManager gort_MM;
    
    void Start()
    {
        goobert_PI.enabled = true;
        goobert_MM.enabled = true;
        gort_PI.enabled = false;
        gort_MM.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            goobert_PI.enabled = !goobert_PI.enabled;
            goobert_MM.enabled = !goobert_MM.enabled;
            gort_PI.enabled = !gort_PI.enabled;
            gort_MM.enabled = !gort_MM.enabled;
            
        }
    }
}
