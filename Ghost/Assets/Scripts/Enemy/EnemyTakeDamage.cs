using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    [SerializeField] private EnemyLifeBar enemyLifeBar;
    [SerializeField] private PlayerGun playerGun;
    [SerializeField] private float maxHealth;
    [SerializeField] private float health;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        health = maxHealth;
        enemyLifeBar.UpdateHealthbar(maxHealth, health);
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerGun.damageActive == false)
        {
            spriteRenderer.color = Color.white;
        }

    }

    public void EnemyGetDamage(float damage)
    {

        health -= damage;
        enemyLifeBar.UpdateHealthbar(maxHealth, health);

        if (health > 0)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
