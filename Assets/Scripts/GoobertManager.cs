using System;
using Player;
using UnityEngine;


public class GoobertManager : PlayerManager 
{
    [SerializeField] private GameObject mesh;
    [SerializeField] private Transform gortHead;

    
    private bool _isOnGort = false;

    public void Awake() 
    {
    }

    public void LateUpdate()
    {
        if (_isOnGort)
        {
            transform.position = gortHead.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoobertAttacher") &&  !_isOnGort)
        {
            AttachGoobertToGort();
        }
    }
    

    private void AttachGoobertToGort()
    {
        CharacterController.enabled = false;
        _isOnGort = true;
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
