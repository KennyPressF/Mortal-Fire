using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPSlider : MonoBehaviour
{
    PlayerXP playerXP;
    Slider xpSlider;

    private void Awake()
    {
        playerXP = FindObjectOfType<PlayerXP>();
        xpSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        xpSlider.maxValue = playerXP.GetNextLevelXP();
        xpSlider.value = 0;
    }

    public void SetMaxValue(float value)
    {
        xpSlider.maxValue = value;
    }

    public void UpdateXPSlider(float value)
    {
        xpSlider.value = value;
    }
}
