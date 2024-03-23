using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealt = 100f;
    EnemyAI enemy;

    public GameObject bloodEffect;



    private void Start()
    {
        enemy = GetComponent<EnemyAI>();
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
        enemyHealt -= reduceHealth;
       
        if(!enemy.isDead)
        {
            enemy.Hit();
        }
        if(enemyHealt<=0)
        {
            enemy.DeadAnim();
            Dead();
        }
       
    }

    void Dead()
    {
        bloodEffect.SetActive(true);
        enemy.canAttack = false;
        Destroy(gameObject,10f);
    }
}
