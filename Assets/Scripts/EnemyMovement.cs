using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    [SerializeField] private GameObject target;

    SpriteRenderer mySR;

    Timer timer;

    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
        mySR = GetComponentInChildren<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (timer.keepTime == true)
        {
            target = FindObjectOfType<PlayerHealth>().gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            MoveTowardsPlayer();
            FlipSprite();
        }
    }

    private void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, (moveSpeed * Time.deltaTime));
    }

    private void FlipSprite()
    {
        if (target.transform.position.x < transform.position.x)
        {
            mySR.flipX = true;
        }
        else
        {
            mySR.flipX = false;
        }
    }
}
