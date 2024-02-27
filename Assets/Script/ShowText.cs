using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShowText : MonoBehaviour
{
    [SerializeField] private GameObject StartText;
    [SerializeField] private float Timer;
    [SerializeField] private GameObject image;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            StartText.SetActive(true);
            image.SetActive(true);
            
        }
    }
}
