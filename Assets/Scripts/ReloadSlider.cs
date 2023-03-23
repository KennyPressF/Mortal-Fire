using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadSlider : MonoBehaviour
{
    Slider reloadSlider;
    PlayerCombat playerCombat;

    private void Awake()
    {
        playerCombat = FindObjectOfType<PlayerCombat>();
        reloadSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        SetSliderMaxValue();
        reloadSlider.value = reloadSlider.maxValue;
    }

    public void SetSliderMaxValue()
    {
        float maxValue = playerCombat.GetMaxReloadTime();
        reloadSlider.maxValue = maxValue;
    }

    public void UpdateReloadSlider(float value)
    {
        reloadSlider.value = value;
    }
}
