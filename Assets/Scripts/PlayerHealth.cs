using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth;

    GameManager gameManager;
    HealthSlider healthSlider;
    Timer timer;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        healthSlider = FindObjectOfType<HealthSlider>();
        timer = FindObjectOfType<Timer>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthSlider.UpdateHealthSlider(currentHealth);

        if(currentHealth >= 1)
        {
            AudioManager.instance.PlayAudioClip("Player Hurt SFX");
        }

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        timer.StopTimer();
        gameManager.GameOver();
        Destroy(gameObject);
    }

    public float GetMaxPlayerHealth()
    {
        return maxHealth;
    }

    public float GetCurrentPlayerHealth()
    {
        return currentHealth;
    }

    public void IncreaseMaxHealth(float health)
    {
        maxHealth += health;
        currentHealth = maxHealth;
        healthSlider.UpdateHealthSlider(currentHealth);
    }
}
