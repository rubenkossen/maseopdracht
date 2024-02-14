using UnityEngine;

public class OpenDoor : MonoBehaviour
{
   [SerializeField] private Animator m_animator;
   
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         m_animator.SetBool("Door",true);
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         m_animator.SetBool("Door",false);
      }
   }
}
