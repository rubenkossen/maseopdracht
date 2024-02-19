using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackmove : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private int damage;
    
    
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            EnemyStats enemyplayerStats = other.collider.GetComponent<EnemyStats>();
            
            
            enemyplayerStats.TakeDamage(damage);
            
            Destroy(gameObject);
        }
        if (other.collider.CompareTag("Player"))
        {
            PlayerHealth playerAttackStats = other.collider.GetComponent<PlayerHealth>();
            playerAttackStats.TakeDamage(damage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
