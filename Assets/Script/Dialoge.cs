using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialoge : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextComponent;
    [SerializeField] private TextMeshProUGUI TitleComponent;
    [SerializeField] private Image ImageComponent;

    [SerializeField] private string[] Title;
    [SerializeField] private  string[] lines;
    [SerializeField] private Sprite[] mysprites;

    [SerializeField] private float textspeed = 0.5f;

    private int index;
    void Start()
    {
        TextComponent.text = string.Empty;
        TitleComponent.text = string.Empty;
        startDailogo();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TextComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                TextComponent.text = lines[index];
                TitleComponent.text = Title[index];
                updateCharacterInfo();
            }
        }
    }

    void startDailogo()
    {
        index = 0;
        StartCoroutine(TypeLine());
        
        updateCharacterInfo();
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            TextComponent.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            TextComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            
            updateCharacterInfo();
        }
        else
        {
            SceneManager.LoadScene("map");
        }
    }

    void updateCharacterInfo()
    {
        if (index < Title.Length)
        {
            TitleComponent.text = Title[index];
        }

        if (index < mysprites.Length)
        {
            ImageComponent.sprite = mysprites[index];
        }
    }
}
