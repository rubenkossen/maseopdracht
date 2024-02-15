using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialoge : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] Lines;
    [SerializeField] private float textSpeed;

    private int index;
    void Start()
    {
        textComponent.text = string.Empty;
        startDialoge();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == Lines[index])
            {
                nextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = Lines[index];
            }
        }
    }

    void startDialoge()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in Lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void nextLine()
    {
        if (index < Lines.Length - 1)
        {
            index++;
            textComponent.text = String.Empty;
            StartCoroutine(TypeLine());
        }
    }
}
