using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using TMPro;
public class EnemyStats : MonoBehaviour
{
    public int EnemyHp;
    public int EnemyStrength;
    public int EnemyDefence;
    public int EnemySpeed;
    public TMP_Text HPText;
    void Update()
    {
        HPText.text = EnemyHp.ToString();
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

