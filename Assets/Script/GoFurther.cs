using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoFurther : MonoBehaviour
{
    [SerializeField] public GameObject Menu;
    [SerializeField] public GameObject IngameUI;
    [SerializeField] private GameObject Player;
    
    
    public Gun gundiss;
    public MenuUI UIBool;
    
    public void goFurther()
    {
        UIBool.MenuBool = true;
        gundiss.enabled = true;
        
        Time.timeScale = 1;
        if (Time.timeScale != 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        Menu.SetActive(false);
        IngameUI.SetActive(true);
       
    }
}