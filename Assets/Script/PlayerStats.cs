using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int hp;
    public int strength;
    public int defence;
    public int speed;
    
    void Update()
    {
        
    }

    public void TakeDamage(int enemystrenght)
    {
        hp -= enemystrenght;

        if (hp <= 0)
        {
           Die(); 
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
