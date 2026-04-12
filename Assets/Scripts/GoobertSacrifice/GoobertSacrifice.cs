using System.Collections;
using Interaction;
using Player;
using UnityEngine;

namespace GoobertSacrifice
{
    public class GoobertSacrifice: MonoBehaviour, Interactable
    {
        public Transform GoobertSocket;
        public float unlockDelay = 3f;
        public bool isPressed = false;
        public void Activate(PlayerManager playerManager)
        {
            if (playerManager is GortManager gortManager)
            {
                if (gortManager.isCarryingGoobert)
                {
                    gortManager.SacrificeGoobert(GoobertSocket);
                    gortManager.canGrab = false;
                    StartCoroutine(SacrificeGoobertSequence(playerManager));    
                    isPressed = true;
                }
            }
            Debug.Log("Goobert Sacrifice activated");
        }

        public GameObject GetGameObject()
        {
            return gameObject;
        }

        public IEnumerator SacrificeGoobertSequence(PlayerManager playerManager)
        {
            yield return new WaitForSeconds(unlockDelay);
            if (playerManager is GortManager gortManager)
            {
                gortManager.canGrab = true;
                gortManager.FreeGoobert();
            }
        }

        public bool CanInteract(PlayerManager playerManager)
        {
            return playerManager is GortManager;
        }
    }
}