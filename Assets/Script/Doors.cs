using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private List<GameObject> Gates;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            for (int i = 0; i < Gates.Count; i++)
            {
                //StartCoroutine(animationcoroutine());
                bool result = Random.Range(1, 3) == 2;     
                Gates[i].SetActive(result);
            }
        }
    }

    IEnumerator animationcoroutine()
    {
        yield return new WaitForSeconds(1);
        ///make animation work with this
        //m_animator.SetTrigger("DoorOpen");
    }
}
