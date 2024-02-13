using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int EnemyHp;
    public int EnemyStrength;
    public int EnemyDefence;
    public int EnemySpeed;
    void Update()
    {
       
    }

    public void TakeDamage(int damage)
    {
        EnemyHp -= damage;
        
        if (EnemyHp <= 0)
        {
            Die(); 
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

