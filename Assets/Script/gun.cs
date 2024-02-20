using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.Serialization;

public class gun : MonoBehaviour
{
    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private Transform shootpoint;
    [SerializeField] private int Ammo;
    [SerializeField] private int MaxMags;
    int AmmoOff;
    
    public bool shot = true;

    [SerializeField] private float Timer;
    [SerializeField] private float resetTimer;

    [SerializeField] private AudioClip soundClip;
    private AudioSource _audioSource;
    
    [SerializeField] private TMP_Text AmmoText;
    [SerializeField] private TMP_Text Ammoleft;

    [SerializeField] private Animator m_amotor;
    

    private void Start()
    {
        AmmoOff = Ammo;
        _audioSource = GetComponent<AudioSource>();
        m_amotor = GetComponent<Animator>();

        _audioSource.clip = soundClip;
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        AmmoText.text = Ammo.ToString();
        Ammoleft.text = MaxMags.ToString();
        
        if (Input.GetKeyDown(KeyCode.R) && MaxMags >= 1)
        {
            shot = false;
            StartCoroutine(reload());
            m_amotor.SetBool("bool", true);
        }
        else if (Ammo == 0 && MaxMags >= 1)
        {
            shot = false;
            m_amotor.SetBool("shooting", false);
            m_amotor.SetBool("bool", true);
            StartCoroutine(reload());
        }
        
        if (Input.GetMouseButton(0) && Ammo >= 1 && Timer <= 0 && shot == true)
        {
            m_amotor.SetBool("shooting", true);
            _audioSource.Play();
            shoot();
            Ammo -= 1;
            Timer = resetTimer;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_amotor.SetBool("shooting", false);
        }
    }

    IEnumerator reload()
    {
        AmmoOff -= Ammo;
        if (MaxMags >= 1 && MaxMags <= 49)
        {
            MaxMags -= AmmoOff;
            Ammo = MaxMags;
        }
        else
        {
            MaxMags -= AmmoOff;
            Ammo = 50;
        }
        
        AmmoOff = Ammo;
        m_amotor.SetBool("bool", false);
        shot = true;
        yield return new WaitForSeconds(2);

    }
    

    void shoot()
    {
        GameObject bullet = Instantiate(attackPrefab, shootpoint.position, Quaternion.identity);
        bullet.transform.rotation = transform.rotation;
    }
}
