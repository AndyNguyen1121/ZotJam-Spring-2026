using System;
using Player;
using UnityEngine;

public class GortManager : PlayerManager
{
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
