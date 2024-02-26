using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    [SerializeField] public GameObject Menu;
    [SerializeField] public GameObject IngameUI;
    
    public Gun gundiss;
    public void startButton()
    {
        SceneManager.LoadScene("Intro");
    }

    public void QUITButton()
    {
        Application.Quit();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }

    public void goFurther()
    {
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
