using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int hp;
    public int strength;
    public int defence;
    public int speed;

    public TMP_Text HPText;
    void Update()
    {
        HPText.text = hp.ToString();
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
