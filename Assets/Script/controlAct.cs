using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlAct : MonoBehaviour
{
    [SerializeField] private GameObject ButtonToActiveit;
    [SerializeField] private GameObject turnOff;
    
    private bool control1, control2;
    [SerializeField] private int start;
    
    void Update()
    {
        if (start >= 1)
        {
           turnOff.SetActive(false); 
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                switch (control1)
                {
                    case false:
                        start += 1;
                        control1 = true;
                        ButtonToActiveit.SetActive(false);
                        break;
                    case true:
                        Debug.Log("works");
                        break;
                }
            }
            switch (control1)
            {
                case false:
                    ButtonToActiveit.SetActive(true);
                    break;
                case true:
                    ButtonToActiveit.SetActive(false);
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ButtonToActiveit.SetActive(false);
    }
}
