using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackmove : MonoBehaviour
{
    [SerializeField] private float timer;

    private PlayerStats _playerStats;
    private EnemyStats _enemyStats;
    void Start()
    {
        _playerStats = GetComponentInParent<PlayerStats>();
        _enemyStats = GetComponentInParent<EnemyStats>();
    }
    
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
            EnemyStats enemyPlayerStats = other.collider.GetComponent<EnemyStats>();
            
            if (enemyPlayerStats != null && _playerStats != null)
            {
                enemyPlayerStats.TakeDamage(_playerStats.strength);
            }
            Destroy(gameObject);
        }
        if (other.collider.CompareTag("Player"))
        {
            EnemyStats enemyPlayerStats = other.collider.GetComponent<EnemyStats>();
            
            if (enemyPlayerStats != null && _playerStats != null)
            {
                _playerStats.TakeDamage(_enemyStats.EnemyStrength);
            }
            Destroy(gameObject);
        }
    }
}
