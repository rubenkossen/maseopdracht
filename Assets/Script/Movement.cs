using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float gravity = -20;
    
    Vector3 velocity;
    
    [SerializeField] private AudioClip soundClip;
    private AudioSource _audioSource;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _audioSource.clip = soundClip;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S))
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }
}
