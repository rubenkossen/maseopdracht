using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Animator m_animator;
    public List<GameObject> Gates;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            for (int i = 0; i < Gates.Count; i++)
            {
                StartCoroutine(animationcoroutine());
                bool result = Random.Range(1, 3) == 2;     
                Gates[i].SetActive(result);
            }
        }
    }

    IEnumerator animationcoroutine()
    {
        yield return new WaitForSeconds(1);
        
        m_animator.SetTrigger("DoorOpen");
    }
}
