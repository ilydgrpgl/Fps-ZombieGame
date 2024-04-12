using UnityEngine;
using UnityEngine.AI;
using System.Collections; // IEnumerator kullanacaðýnýz için bu satýrý ekleyin

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    Transform target;
    public bool isDead = false;
    public float turnSpeed;

    private AttackManager attackManager;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        attackManager = GetComponent<AttackManager>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < 10 && distance > agent.stoppingDistance && !isDead)
        {
            
            ChasePlayer();
           
        }
        else if (distance <= agent.stoppingDistance && !isDead)
        {
            StopChase();
            if (attackManager != null)
            {
                attackManager.StartAttack(target);
            }
        }
    }

    void StopChase()
    {
        agent.isStopped = true;
        animator.SetBool("isWalking", false);
        animator.SetBool("Attack", false);
    }

    void ChasePlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(target.position);
        animator.SetBool("isWalking", true);
        animator.SetBool("Attack", false);
    }

    public void Hit()
    {
        if (!isDead)
        {
            agent.isStopped = true;
            animator.SetTrigger("Hit");
            StartCoroutine(RecoverFromHit());
        }
    }

    private IEnumerator RecoverFromHit()
    {
        yield return StartCoroutine(RecoverRoutine());
    }

    private IEnumerator RecoverRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        agent.isStopped = false;
    }


    public void DeadAnim()
    {
        isDead = true;
        agent.isStopped = true;
        animator.SetTrigger("Dead");
    }
}
