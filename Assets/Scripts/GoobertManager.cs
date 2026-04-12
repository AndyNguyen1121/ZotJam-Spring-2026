using System;
using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.Splines;


public class GoobertManager : PlayerManager 
{
    [SerializeField] GortManager gortManager;
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
                DetachGoobertFromSocket();
                MovementManager.Jump();
            }
        }
        else
        {
            timeElapsedSinceLastOnGort += Time.deltaTime;
        }
    }

    public void LateUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoobertAttacher") &&  !isOnGort && timeElapsedSinceLastOnGort > 5f)
        {
            if (gortManager.canGrab)
                AttachGoobertToGort();
        }
    }
    

    private void AttachGoobertToGort()
    {
        CharacterController.enabled = false;
        gortManager.isCarryingGoobert = true;
        isOnGort = true;
        transform.parent = gortHead;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
    
    public void DetachGoobertFromSocket()
    {
        CharacterController.enabled = true;
        transform.parent = null;
        isOnGort = false;
        gortManager.isCarryingGoobert = false;
    }

    public void EnterPipe() {
        InputManager.BlockInput(this);
        mesh.SetActive(false);
    }

    public void ExitPipe() {
        InputManager.UnblockInput(this);
        mesh.SetActive(true);
    }

    public void AttachGoobertToSocket(Transform socket)
    {
        // deattach from current socket
        DetachGoobertFromSocket();
        
        // attach to new socket
        CharacterController.enabled = false;
        transform.parent = socket;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
    
    
}
