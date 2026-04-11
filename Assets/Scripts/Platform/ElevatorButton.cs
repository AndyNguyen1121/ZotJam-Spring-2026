using System;
using Interaction;
using Platform;
using Player;
using UnityEngine;

public class ElevatorButton : MonoBehaviour, Interactable
{
   [SerializeField] MovingPlatform  movingPlatform;
   
   public void Activate(PlayerManager playerManager)
   {
      if (movingPlatform.splineAnimator != null && !movingPlatform.splineAnimator.IsPlaying)
      {
         movingPlatform.splineAnimator.Play();
      }
         
   }

   public GameObject GetGameObject()
   {
      return gameObject;
   }
}
