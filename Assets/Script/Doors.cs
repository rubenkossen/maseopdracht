using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public List<GameObject> Gates;

    public int currentActiveIndex = 0;
    void Start()
    {
        //bool result = Random.Range(1, 3) == currentActiveIndex;
    }

    
    void Update()
    {
        //currentActiveIndex = Gates.Count - 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            for (int i = 0; i < Gates.Count; i++)
            {
                bool result = Random.Range(1, 3) == 2;     
                Gates[i].SetActive(result);
            }
        }
    }
}
