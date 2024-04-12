using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100;
    public bool isDead;
    public Slider healthBar;

    public static PlayerHealth PH;

    [Header("Damage Screen")]
    public Color damageColor;
    public Image damageImage;
    bool isTalkingDamage = false;
    float colorSpeed = 0.7f;

    

    private void Awake()
    {
        PH = this;//  singleton pattern
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.value = maxHealth;
    }


    void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        if (isTalkingDamage)
        {
            damageImage.color = damageColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, colorSpeed * Time.deltaTime);
        }
        isTalkingDamage = false;
    }
    public void DamagePlayer(float damage)
    {

        if (currentHealth > 0)
        {
            if (damage >= currentHealth)
            {
                isTalkingDamage = true;
                Dead();
            }
            else
            {
                isTalkingDamage = true;
                currentHealth -= damage;
                healthBar.value -= damage;
            }

        }

    }


    void Dead()
    {
        currentHealth = 0;
        isDead = true;
        healthBar.value = 0;
        SceneManager.LoadScene(1);
       
    }
}
