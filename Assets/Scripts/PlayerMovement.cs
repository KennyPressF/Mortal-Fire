using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    Vector2 moveDirection;
    Vector2 mousePosition;
    Vector2 mouseToWorldPosition;

    [SerializeField] float maxXPos;
    [SerializeField] float minXPos;
    [SerializeField] float maxYPos;
    [SerializeField] float minYPos;

    Rigidbody2D myRB;
    SpriteRenderer mySR;
    Animator myAnim;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        mySR = GetComponentInChildren<SpriteRenderer>();
        myAnim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        ConstrainPosition();
        FlipSprite();

        if(myRB.velocity == Vector2.zero)
        {
            myAnim.Play("Player_Idle");
        }
        else
        {
            myAnim.Play("Player_Move");
        }
    }

    private void FixedUpdate()
    {
        myRB.velocity = (moveDirection * moveSpeed) * Time.deltaTime;
    }
    private void ConstrainPosition()
    {
        if (transform.position.x > maxXPos) { transform.position = new Vector2(maxXPos, transform.position.y); }
        if (transform.position.x < minXPos) { transform.position = new Vector2(minXPos, transform.position.y); }
        if (transform.position.y > maxYPos) { transform.position = new Vector2(transform.position.x, maxYPos); }
        if (transform.position.y < minYPos) { transform.position = new Vector2(transform.position.x, minYPos); }
    }

    private void FlipSprite()
    {
        mousePosition = Mouse.current.position.ReadValue();
        mouseToWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (mouseToWorldPosition.x < transform.position.x)
        {
            mySR.flipX = true;
        }
        else if (mouseToWorldPosition.x > transform.position.x)
        {
            mySR.flipX = false;
        }
    }

    private void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    public float GetCurrentMoveSpeed()
    {
        return moveSpeed;
    }

    public void IncreaseMoveSpeed(float speedToAdd)
    {
        moveSpeed += speedToAdd;
    }
}
