using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    
    [SerializeField] private float timer;
    [SerializeField] private int damage;
    [SerializeField] private int Heal = 10;
    
    void Update()
    {
        timer -= Time.deltaTime;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            EnemyHealth enemyplayerHealth = other.collider.GetComponent<EnemyHealth>();
            
            enemyplayerHealth.TakeDamage(damage);

            PlayerHealth playerAttackStats = GetComponentInParent<PlayerHealth>();
            
            playerAttackStats.Healing(Heal);
            
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
