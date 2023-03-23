using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] float shootTimer;
    [SerializeField] float maxShootTimer;
    [SerializeField] bool canShoot;

    ReloadSlider reloadSlider;

    Gun gun;

    private void Awake()
    {
        gun = GetComponentInChildren<Gun>();
        reloadSlider = FindObjectOfType<ReloadSlider>();
    }

    private void Start()
    {
        canShoot = true;
        shootTimer = maxShootTimer;
    }

    private void OnFire()
    {
        if(!canShoot)
        {
            return;
        }

        gun.Shoot();

        shootTimer = 0;
        canShoot = false;
    }

    private void Update()
    {
        if(!canShoot)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= maxShootTimer)
            {
                canShoot = true;
            }
        }

        reloadSlider.UpdateReloadSlider(shootTimer);
    }

    public float GetMaxReloadTime()
    {
        return maxShootTimer;
    }

    public float GetCurrentReloadTime()
    {
        return shootTimer;
    }

    public void DecreaseReloadTime(float time)
    {
        maxShootTimer -= time;
        reloadSlider.SetSliderMaxValue();
    }
}
