using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour


{
    public bool canAttack = true;
    private float attackTimer = 2f;
    float damage = 25f;
    Animator animator;

   
        private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAttack(Transform target)
    {
        if (canAttack)
        {
            StartCoroutine(AttackRoutine(target));
        }
    }

   IEnumerator AttackRoutine(Transform target)
    {
        canAttack = false;
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(attackTimer);
        DealDamage(target);
        canAttack = true;
    }

    private void DealDamage(Transform target)
    {
        
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.DamagePlayer(damage);
        }
    }
}
