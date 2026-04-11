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
        public void Activate(PlayerManager playerManager)
        {
            if (playerManager is GortManager gortManager)
            {
                if (gortManager.isCarryingGoobert)
                {
                    gortManager.SacrificeGoobert(GoobertSocket);
                    gortManager.canGrab = false;
                    StartCoroutine(SacrificeGoobertSequence(playerManager));    
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
    }
}