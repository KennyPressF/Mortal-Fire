using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCredits : MonoBehaviour
{
    [SerializeField] GameObject creditsPanel;

    private void Start()
    {
        creditsPanel.SetActive(false);
    }

    public void ToggleCreditsPanel()
    {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
    }
}
