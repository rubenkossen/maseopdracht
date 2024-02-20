using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private List<Transform> Targets;

    [SerializeField] private float speed;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private float Timer;
    [SerializeField] private float resetTimer;

    [SerializeField] private float offset;
    [SerializeField] private float range;
    [SerializeField] private GameObject AttackPrefab;

    public Transform shootpoint;
    private Transform target;
    private Transform closestTarget;

    [SerializeField] private Animator _animator;
    

    void Update()
    {
        Timer -= Time.deltaTime;
        enemyInRange();
    }

    void enemyInRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "Player" && collider.transform != transform)
            {
                if (!Targets.Contains(collider.transform))
                {
                    Targets.Add(collider.transform);
                    target = Targets[0];
                }
                GetClosestEnemy();
            }
            else
            {
                Targets.Clear();
            }
        }
    }
    void GetClosestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        
        foreach (Transform target in Targets)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = target;
                moveTowardsTarget();
            }
        }
    }
    void moveTowardsTarget()
    {
        float distanceToTarget = Vector3.Distance(transform.position, closestTarget.position);

        if (Vector3.Distance(transform.position, closestTarget.position) < offset)
        {
            attacking();
        }
        else
        {
            _animator.SetBool("Run", true);
            float effectivespeed = Mathf.Min(speed, distanceToTarget / 2f);
            transform.position = Vector3.MoveTowards(transform.position, closestTarget.position, effectivespeed * Time.deltaTime);
        }
        
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationSpeed * Time.deltaTime);

    }


    void attacking()
    {
        if (Timer <= 0)
        {
            _animator.SetBool("Shot", true);
            GameObject b = Instantiate(AttackPrefab, shootpoint.position, Quaternion.identity);
            b.transform.rotation = transform.rotation;
            Timer = resetTimer;
        }
        else
        {
            _animator.SetBool("Aim", true);
        }
        
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}


