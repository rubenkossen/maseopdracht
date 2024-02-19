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
    
    [SerializeField] private TMP_Text HPText;

    [SerializeField] private Slider sliderUI;
    [SerializeField] private Image HealthFill;
    

    private void Start()
    {
        sliderUI.maxValue = hp;
        HPText.text = hp.ToString();
    }

    void Update()
    {
        sliderUI.value = hp;
        if (hp <= 0)
        {
            sliderUI.gameObject.SetActive(false);
            Die();
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
        SceneManager.LoadScene("DeathScene");
    }
}
