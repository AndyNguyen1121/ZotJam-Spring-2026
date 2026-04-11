using System;
using Goobert;
using Player;
using UnityEngine;

public class GortManager : PlayerManager
{
    [SerializeField] GoobertManager goobertManager;
    public bool isCarryingGoobert;
    public bool canGrab;

    private void Start()
    {
        canGrab = true;
    }

    public void SacrificeGoobert(Transform socket)
    {
        goobertManager.AttachGoobertToSocket(socket);
    }

    public void FreeGoobert()
    {
        goobertManager.DetachGoobertFromSocket();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // just assuming we only pushing around the crate
        if (hit.gameObject.layer == LayerMask.NameToLayer("GortOnly"))
        {
            Rigidbody rb = hit.rigidbody;
            if (rb == null || rb.isKinematic) return;

            rb.AddForce(hit.moveDirection, ForceMode.Impulse);
        }
    }
}
