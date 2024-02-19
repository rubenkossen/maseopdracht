using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingWalls : MonoBehaviour
{
    [SerializeField] private float Timer;
    [SerializeField] private float resetTimer;
    
    [SerializeField] private List<GameObject> Gates;
    
    
    void Start()
    {
        
    }
    
    void Update()
    {
        Timer -= Time.deltaTime;
        
            if (Timer <= 0)
            {
                for (int i = 0; i < Gates.Count; i++)
                {
                    bool result = Random.Range(1, 3) == 2;
                    Gates[i].SetActive(result);
                    
                    Timer = resetTimer;
                }
            }  
           
        

        
    }
}
