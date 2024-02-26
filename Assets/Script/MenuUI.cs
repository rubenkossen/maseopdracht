using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] public GameObject Menu;
    [SerializeField] public GameObject IngameUI;

    private Gun gundiss;
    

    public bool MenuBool = true;

    private void Start()
    {
        gundiss = GetComponent<Gun>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuBool == true)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Menu.SetActive(true);
                IngameUI.SetActive(false);
                MenuBool = false;
                gundiss.enabled = false;

            }
            else if (MenuBool == false)
            {
                gundiss.enabled = true;
                Time.timeScale = 1;
                if (Time.timeScale != 0)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
                Menu.SetActive(false);
                IngameUI.SetActive(true);
                MenuBool = true;
            }       
        }
    }
}
