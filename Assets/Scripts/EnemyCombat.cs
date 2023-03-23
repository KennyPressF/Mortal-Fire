using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] float damageStrength;
    [SerializeField] float cooldownTimer;
    [SerializeField] float maxTimer;

    public bool canHit;

    PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnEnable()
    {
        cooldownTimer = maxTimer;
    }

    private void Update()
    {
        if(cooldownTimer < maxTimer)
        {
            canHit = false;
            cooldownTimer += Time.deltaTime;
        }
        else
        {
            canHit = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && canHit == true)
        {
            playerHealth.TakeDamage(damageStrength);
            cooldownTimer = 0;
        }
    }
}
