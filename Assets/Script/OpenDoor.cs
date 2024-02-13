using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
   public Animator m_animator;
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         m_animator.SetTrigger("DoorOpen");
      }
   }
}
