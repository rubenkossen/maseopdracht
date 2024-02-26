using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private float Timer;
    
    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            SceneManager.LoadScene("mainmenu");
        }
        Time.timeScale = 0;
    }
}
