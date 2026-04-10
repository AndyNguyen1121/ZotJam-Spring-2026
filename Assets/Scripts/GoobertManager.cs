using System;
using Player;
using UnityEngine;


public class GoobertManager : PlayerManager {
    [SerializeField] private GameObject mesh;
    
    private void Awake() {
        
    }

    public void EnterPipe() {
        InputManager.BlockInput(this);
        mesh.SetActive(false);
    }

    public void ExitPipe() {
        InputManager.UnblockInput(this);
        mesh.SetActive(true);
    }
}
