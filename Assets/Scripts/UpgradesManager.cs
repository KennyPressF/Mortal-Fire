using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] GameObject upgradesPanel;

    GameManager gameManager;
    PlayerHealth playerHealth;
    PlayerCombat playerCombat;
    PlayerMovement playerMovement;
    XPCollector xpCollector;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        xpCollector = FindObjectOfType<XPCollector>();
    }

    private void Start()
    {
        upgradesPanel.SetActive(false);
    }

    public void ToggleUpgradesScreen()
    {
        upgradesPanel.SetActive(!upgradesPanel.activeSelf);

        if(upgradesPanel.activeSelf == true) { pauseButton.interactable = false; }
        else { pauseButton.interactable = true; }
    }

    public void Upgrade_IncreaseHealth()
    {
        float currentMaxHealth = playerHealth.GetMaxPlayerHealth();
        float healthToAdd = currentMaxHealth * 0.1f;
        playerHealth.IncreaseMaxHealth(healthToAdd);
        ToggleUpgradesScreen();
        gameManager.StartTime();
    }

    public void Upgrade_FasterReloads()
    {
        float currentReloadTimer = playerCombat.GetMaxReloadTime();
        float timeToDecrease = currentReloadTimer * (0.05f);
        playerCombat.DecreaseReloadTime(timeToDecrease);
        ToggleUpgradesScreen();
        gameManager.StartTime();
    }

    public void Upgrade_IncreaseSpeed()
    {
        float currentMoveSpeed = playerMovement.GetCurrentMoveSpeed();
        float speedToAdd = currentMoveSpeed * 0.2f;
        playerMovement.IncreaseMoveSpeed(speedToAdd);
        ToggleUpgradesScreen();
        gameManager.StartTime();
    }

    public void Upgrade_WiderXPCollection()
    {
        float currentCollectorSize = xpCollector.GetCollectorSize();
        float sizeToIncrease = currentCollectorSize * 0.25f;
        xpCollector.IncreaseCollectorSize(sizeToIncrease);
        ToggleUpgradesScreen();
        gameManager.StartTime();
    }
}
