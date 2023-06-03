using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    Animator animator;
    Transform target;
    private bool isDead = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= 2 && !isDead)
        {
            AttackPlayer();
        }

        else if (distance < 10 && distance > 2 && !isDead)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        agent.updatePosition = true;
        agent.SetDestination(target.position);
        animator.SetBool("isWalking", true);
        animator.SetBool("Attack", false);
    }

    void AttackPlayer()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),8f * Time.deltaTime);

        agent.updatePosition = false;
        animator.SetBool("isWalking", false);
        animator.SetBool("Attack", true);
    }

    public void ZombieDead()
    {
        isDead = true;
        animator.SetTrigger("Dead");
        agent.isStopped = true;
    }
}
