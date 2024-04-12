using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealt = 100f;
    public GameObject bloodEffect;

    private AttackManager attackManager;
    private EnemyAI enemy;
 

    private void Start()
    {
        enemy = GetComponent<EnemyAI>();
        attackManager = GetComponent<AttackManager>();
      
    }
    private void Update()
    {
        if (enemyHealt <= 0)
        {

            enemyHealt = 0;
        }
    }

    public void ReduceHealth(float reduceHealth)
    {
        if (!(reduceHealth < 0))
        {
            enemyHealt -= reduceHealth;

            if (enemy != null)
            {
                if (!enemy.isDead)
                {
                    enemy.Hit();
                }
                if (enemyHealt <= 0)
                {
                    enemy.DeadAnim();
                    Dead();
                }
            }

        }


    }

    void Dead()
    {
        if(attackManager!= null)
        {
            bloodEffect.SetActive(true);
            attackManager.canAttack = false;
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, 6f);
        }
        
    }
}
