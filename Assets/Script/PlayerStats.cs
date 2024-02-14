using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int hp;
    
    [SerializeField] private TMP_Text HPText;

    private void Start()
    {
        HPText.text = hp.ToString();
    }

    void Update()
    {
       
        
    }

    public void TakeDamage(int enemystrenght)
    {
        HPText.text = hp.ToString();
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
