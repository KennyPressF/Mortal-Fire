using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPPickup : MonoBehaviour
{
    [SerializeField] float XPValue;
    [SerializeField] float scoreValue;
    [SerializeField] float moveSpeed;
    [SerializeField] bool isCollected = false;

    GameObject target;
    Transform targetPosition;

    PlayerXP playerXP;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        playerXP = FindObjectOfType<PlayerXP>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnEnable()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    public void StartCollection()
    {
        isCollected = true;
    }

    private void Update()
    {
        if (isCollected == true && target != null)
        {
            targetPosition = target.transform;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerXP.AddToXP(XPValue);
            scoreKeeper.AddToScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
