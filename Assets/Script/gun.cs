using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class gun : MonoBehaviour
{
    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private Transform shootpoint;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }

    void shoot()
    {
        GameObject bullet = Instantiate(attackPrefab, shootpoint.position, Quaternion.identity);
        bullet.transform.rotation = transform.rotation;
    }
}
