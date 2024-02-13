using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject attackprefab;
    public GameObject enemypos;
    public GameObject playerpos;
    private bool enemyTurn;

    public GameObject turnoffenemyturn;
    private bool attackinstantiated;
    
    public void Attack()
    {
        GameObject B = Instantiate(attackprefab, enemypos.transform.position, Quaternion.identity);
        B.transform.parent = transform;
        enemyTurn = true;
    }

    private void Update()
    {
        if (enemyTurn == true)
        {
            if (!attackinstantiated)
            {
                GameObject B = Instantiate(attackprefab, playerpos.transform.position, Quaternion.identity);
                B.transform.parent = transform;
                attackinstantiated = true;
            }
           
            turnoffenemyturn.SetActive(false);
            StartCoroutine(attackcoroutine());
        }
    }

    IEnumerator attackcoroutine()
    {
        yield return new WaitForSeconds(1);
        
        enemyTurn = false;
        turnoffenemyturn.SetActive(true);
        attackinstantiated = false;
    }
}
