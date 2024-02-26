using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    void Start()
    {
        int RandomNumber = Random.Range(1, 5);

        switch (RandomNumber)
        {
            case 1:
                Destroy(gameObject);
                break;
            case 2:
                break;
            case 3:
                Destroy(gameObject);
                break;
            case 4:
                Destroy(gameObject);
                break;
        }
    }
}
