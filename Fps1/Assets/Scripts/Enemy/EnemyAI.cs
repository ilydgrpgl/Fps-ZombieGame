using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    NavMeshAgent agent;
    Animator animator;
    Transform target;
    public bool isDead=false;
    public float turnSpeed;

   public bool canAttack;
    float attackTimer = 2f;
    float damage = 25f;


    
    void Start()
    {
        canAttack = true;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance= Vector3.Distance(transform.position, target.position);
        if (distance < 10 && distance > agent.stoppingDistance && !isDead)
        {
            ChasePlayer();
        }
        else if (distance <= agent.stoppingDistance && canAttack && !PlayerHealth.PH.isDead)
        {
            agent.updateRotation = false;
            Vector3 Direction = target.position - transform.position;
            Direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Direction), turnSpeed * Time.deltaTime);
            agent.updatePosition = false;
            animator.SetBool("isWalking", false);
            animator.SetBool("Attack", true);
        }
        else if(distance>10)
        {
            StopChase();
        }


    }

    void StopChase()
    {
        agent.updatePosition = false;
        animator.SetBool("isWalking", false);
        animator.SetBool("Attack", false);
    }

    void ChasePlayer()
    {
        agent.updateRotation = true;
        agent.updatePosition = true;
        agent.SetDestination(target.position);
        animator.SetBool("isWalking", true);
        animator.SetBool("Attack", false);
    }

    void AttackPlayer()
    {

        PlayerHealth.PH.DamagePlayer(damage);
        //StartCoroutine(attackTime());// animasyona atýldý

    }

    public void Hit()
    {
        agent.enabled = false;
        animator.SetTrigger("Hit");
        StartCoroutine(Nav());
    }
   public void DeadAnim()
    {
        isDead = true;
        animator.SetTrigger("Dead");
    }
    IEnumerator Nav()
    {
        yield return new WaitForSeconds(1.5f);
        agent.enabled = true;
    }
   
}
