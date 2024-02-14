using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public GameObject attackprefab;
    public GameObject enemypos;
    public GameObject playerpos;
    private bool enemyTurn;
    
    public GameObject turnoffenemyturn;
    private bool attackinstantiated;

    public List<GameObject> Enemys;
    private GameObject enemy;
    public float range;
    public void Attack()
    {
        GameObject B = Instantiate(attackprefab, enemypos.transform.position, Quaternion.identity);
        B.transform.parent = transform;
        turnoffenemyturn.SetActive(false);
        enemyTurn = true;
    }

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        enemyInRange();
        if (enemy == null)
        {
            SceneManager.LoadScene("map");
        }
        
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
    void enemyInRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "Enemy" && collider.transform != transform)
            {
                if (!Enemys.Contains(collider.gameObject))
                {
                    Enemys.Add(collider.gameObject);
                    enemy = Enemys[0];
                }
            }
            else
            {
                Enemys.Clear();
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
