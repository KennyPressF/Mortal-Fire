using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth;
    [SerializeField] float scoreValue;
    [SerializeField] GameObject deathFX;
    [SerializeField] string deathSFXName;

    EnemyLoot enemyLoot;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        enemyLoot = GetComponent<EnemyLoot>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerProjectile"))
        {
            TakeDamage(collision.gameObject.GetComponent<PlayerProjectile>().GetDamageValue());
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        scoreKeeper.AddToScore(scoreValue);
        AudioManager.instance.PlayAudioClip(deathSFXName);
        GameObject deathFXInstance = Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(deathFXInstance, 0.5f);
        enemyLoot.DropXP();
        Destroy(gameObject);
    }
}
