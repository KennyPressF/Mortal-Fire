using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] float damageValue;

    [SerializeField] private float moveSpeed;
    private Vector2 mousePosition;
    private Vector2 mouseToWorldPosition;
    private Vector2 moveDirection;

    [SerializeField] float timeBeforeDestroy;

    Rigidbody2D myRB;

    private void Awake()
    {
        myRB= GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        mousePosition = Mouse.current.position.ReadValue();
        mouseToWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        moveDirection = mouseToWorldPosition - (Vector2)transform.position;

        myRB.velocity = new Vector2(moveDirection.x, moveDirection.y).normalized * moveSpeed;

        Destroy(gameObject, timeBeforeDestroy);
    }

    public float GetDamageValue()
    {
        return damageValue;
    }
}
