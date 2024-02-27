using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int Maxhp;
    
    [SerializeField] public TMP_Text HPText;

    [SerializeField] public Slider sliderUI;
    [SerializeField] public Image HealthFill;

    [SerializeField] public GameObject DeathObject;
    
    
        
    private void Start()
    {
        hp = Maxhp;
        sliderUI.maxValue = hp;
        HPText.text = hp.ToString();
    }

    void Update()
    {
        HPText.text = hp.ToString();
        sliderUI.value = hp;
        if (hp <= 0)
        {
            sliderUI.gameObject.SetActive(false);
            Die();
        }

        if (hp >= Maxhp)
        {
            hp = Maxhp;
        }
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
        DeathObject.SetActive(true);
    }

    public void Healing(int healing)
    {
        hp += healing;
    }
}
