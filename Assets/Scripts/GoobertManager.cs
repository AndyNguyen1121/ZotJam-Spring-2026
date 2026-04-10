using System;
using Player;
using UnityEngine;


public class GoobertManager : PlayerManager 
{
    [SerializeField] private GameObject mesh;
    [SerializeField] private Transform gortHead;

    [SerializeField] private float timeElapsedSinceLastOnGort;

    
    public bool isOnGort = false;

    public void Awake() 
    {
    }

    private void Update()
    {
        if (isOnGort)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                timeElapsedSinceLastOnGort = 0;
                DetachGoobertFromGort();
            }
        }
        else
        {
            timeElapsedSinceLastOnGort += Time.deltaTime;
        }
    }

    public void LateUpdate()
    {
        if (isOnGort)
        {
            transform.position = gortHead.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoobertAttacher") &&  !isOnGort && timeElapsedSinceLastOnGort > 5f)
        {
            AttachGoobertToGort();
        }
    }
    

    private void AttachGoobertToGort()
    {
        CharacterController.enabled = false;
        isOnGort = true;
    }
    
    private void DetachGoobertFromGort()
    {
        CharacterController.enabled = true;
        isOnGort = false;
        MovementManager.Jump();
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
