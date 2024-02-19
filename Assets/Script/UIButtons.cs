using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public void startButton()
    {
        SceneManager.LoadScene("Intro");
    }

    public void QUITButton()
    {
        Application.Quit();
    }
}
