using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationFinished : MonoBehaviour
{
    [SerializeField] private GameObject Despawn, spawnNewImage;
    [SerializeField] private float Timer;

    [SerializeField] private bool whichdis;
    
    
    
    private void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0 && whichdis == true)
        {
            Despawn.SetActive(false);
        }
        else if (Timer <= 0 && whichdis == false)
        {
            Despawn.SetActive(false);
            spawnNewImage.SetActive(true);
        }

    }
}
