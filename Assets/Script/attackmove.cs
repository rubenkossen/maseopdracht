using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackmove : MonoBehaviour
{
    [SerializeField] private float timer;

    public PlayerStats _playerStats;
    public EnemyStats _enemyStats;
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
            //Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            EnemyStats enemyplayerStats = other.collider.GetComponent<EnemyStats>();
            
            if (enemyplayerStats != null && _playerStats != null)
            {
                enemyplayerStats.TakeDamage(_playerStats.strength);
            }
            Destroy(gameObject);
        }
        if (other.collider.CompareTag("Player"))
        {
            PlayerStats playerAttackStats = other.collider.GetComponent<PlayerStats>();
            
            if (_enemyStats != null && _playerStats != null)
            {
                playerAttackStats.TakeDamage(_enemyStats.EnemyStrength);
            }
            //Destroy(gameObject);
        }
    }
}
