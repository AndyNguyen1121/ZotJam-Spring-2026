using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.UI;
using UnityEngine.UI;

public class PlayerSwitchManager : MonoBehaviour
{

    [SerializeField] private PlayerInput goobert_PI;
    [SerializeField] private PlayerInput gort_PI;
    
    [SerializeField] private PlayerMovementManager goobert_MM;
    [SerializeField] private PlayerMovementManager gort_MM;

    [SerializeField] private Image goobert_UI;
    [SerializeField] private Image gort_UI;
    
    void Start()
    {
        goobert_PI.enabled = true;
        goobert_MM.enabled = true;
        gort_PI.enabled = false;
        gort_MM.enabled = false;

        if (goobert_UI) {
            goobert_UI.color = Color.white;
            gort_UI.color = new Color(0.4941177f, 0.7843138f, 0.7764707f, 1f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            goobert_PI.enabled = !goobert_PI.enabled;
            goobert_MM.enabled = !goobert_MM.enabled;
            gort_PI.enabled = !gort_PI.enabled;
            gort_MM.enabled = !gort_MM.enabled;

            if (goobert_UI) {
                (goobert_UI.color, gort_UI.color) = (gort_UI.color, goobert_UI.color);
            }
        }
    }
}
