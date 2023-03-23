using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] GameObject muzzleFlash;
    [SerializeField] Transform muzzleSpawnPoint;

    Vector3 mousePosition;
    Vector3 rotation;
    float rotationAngle;

    SpriteRenderer mySR;

    private void Awake()
    {
        mySR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RotateTowardsMouse();
        FlipSprite();
    }

    private void RotateTowardsMouse()
    {
        rotation = mousePosition - transform.position;
        rotationAngle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
    }

    private void FlipSprite()
    {
        if(mousePosition.x < transform.position.x)
        {
            mySR.flipY = true;
        }

        else if (mousePosition.x > transform.position.x)
        {
            mySR.flipY = false;
        }
    }

    public void Shoot()
    {
        AudioManager.instance.PlayAudioClip("Shoot SFX");
        GameObject muzFlashInstance = Instantiate(muzzleFlash, muzzleSpawnPoint.position, transform.rotation, transform);
        Destroy(muzFlashInstance, 0.1f);
        Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
    }
}
