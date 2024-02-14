using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using TMPro;
public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int EnemyHp;
    
    void Update()
    {
        if (EnemyHp <= 0)
        {
            Die(); 
        }
    }

    public void TakeDamage(int damage)
    {
        EnemyHp -= damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

