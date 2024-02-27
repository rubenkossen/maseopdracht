using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private int damage;
    public float speed;
    
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
        if (other.collider.CompareTag("Player"))
        {
            PlayerHealth playerAttackStats = other.collider.GetComponent<PlayerHealth>();
            playerAttackStats.TakeDamage(damage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
