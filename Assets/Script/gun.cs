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
    public bool shot = true;

    [SerializeField] private float Timer;
    [SerializeField] private float resetTimer;

    [SerializeField] private AudioClip soundClip;
    private AudioSource _audioSource;
    
    [SerializeField] private TMP_Text AmmoText;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _audioSource.clip = soundClip;
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        AmmoText.text = Ammo.ToString();
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            shot = false;
            StartCoroutine(reload());
        }
        else if (Input.GetMouseButton(0) && Ammo >= 0 && Timer <= 0)
        {
            _audioSource.Play();
            shoot();
            Ammo -= 1;
            Timer = resetTimer;
        }
        else
        {
            
        }
    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(2);
        Ammo = 50;
        shot = true;
    }
    

    void shoot()
    {
        GameObject bullet = Instantiate(attackPrefab, shootpoint.position, Quaternion.identity);
        bullet.transform.rotation = transform.rotation;
    }
}
