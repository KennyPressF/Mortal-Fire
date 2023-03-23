using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPCollector : MonoBehaviour
{
    CircleCollider2D myCollider;

    XPPickup xpPickup;

    private void Awake()
    {
        myCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Experience"))
        {
            xpPickup = collision.GetComponent<XPPickup>();
            xpPickup.StartCollection();
        }
    }

    public float GetCollectorSize()
    {
        return myCollider.radius;
    }

    public void IncreaseCollectorSize(float size)
    {
        myCollider.radius += size;
    }
}
