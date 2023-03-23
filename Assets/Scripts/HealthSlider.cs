using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    Slider healthSlider;
    PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        healthSlider = GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetMaxPlayerHealth();
        healthSlider.value = healthSlider.maxValue;
    }

    public void UpdateHealthSlider(float value)
    {
        healthSlider.maxValue = playerHealth.GetMaxPlayerHealth();
        healthSlider.value = value;
    }
}
