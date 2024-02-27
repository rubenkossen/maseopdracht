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
            else
            {
                Time.timeScale = 1;
                if (Time.timeScale != 0)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
                gundiss.enabled = true;
                Menu.SetActive(false);
                IngameUI.SetActive(true);
                MenuBool = true;
            }       
        }
    }
    
    
    public void goFurther()
    {
       
        Time.timeScale = 1;
        if (Time.timeScale != 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            StartCoroutine(courotine());
        }


    }

    private IEnumerator courotine()
    {
        MenuBool = true;
        gundiss.enabled = true;
        
        Menu.SetActive(false);
        IngameUI.SetActive(true);

        yield return new WaitForSeconds(0.1f);
    }
}
