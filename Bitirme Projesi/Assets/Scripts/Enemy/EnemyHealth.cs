using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    EnemyAI enemySc;

    void Start()
    {
        enemySc = GetComponent<EnemyAI>();
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            enemyHealth = 0;
        }
    }

    public void ReduceHealth(float damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            enemySc.ZombieDead();
            Dead();
        }
    }

    void Dead()
    {
        Destroy(gameObject,5f);
    }
}
