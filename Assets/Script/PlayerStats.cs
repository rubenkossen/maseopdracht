using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int hp;
    
    //public TMP_Text HPText;
    void Update()
    {
        //HPText.text = hp.ToString();
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
