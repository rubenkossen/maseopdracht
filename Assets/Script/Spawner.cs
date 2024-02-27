using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    void Start()
    {
        int RandomNumber = Random.Range(1, 7);

        switch (RandomNumber)
        {
            case 1:
                break;
            default:
                Destroy(gameObject);
                break;
                
        }
    }
}
