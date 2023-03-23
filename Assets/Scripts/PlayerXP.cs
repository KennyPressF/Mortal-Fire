using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    [SerializeField] float currentXP;
    [SerializeField] float nextLevelXP;
    [SerializeField] int currentLevel;

    XPSlider xpSlider;
    GameManager gameManager;
    UpgradesManager upgradesManager;
    EnemySpawner enemySpawner;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        upgradesManager = FindObjectOfType<UpgradesManager>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        xpSlider = FindObjectOfType<XPSlider>();
    }

    public float GetNextLevelXP()
    {
        return nextLevelXP;
    }

    public void AddToXP(float xpToAdd)
    {
        currentXP += xpToAdd;
        xpSlider.UpdateXPSlider(currentXP);
        
        if(currentXP < nextLevelXP)
        {
            AudioManager.instance.PlayAudioClip("Collect XP SFX");
        }
        else if(currentXP >= nextLevelXP)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        AudioManager.instance.PlayAudioClip("Level Up SFX");

        currentLevel++;

        IncreaseNextLevelXP();

        enemySpawner.IncreaseWave();
        gameManager.StopTime();
        upgradesManager.ToggleUpgradesScreen();

        currentXP = 0;
        xpSlider.UpdateXPSlider(currentXP);
    }

    private void IncreaseNextLevelXP()
    {
        nextLevelXP += nextLevelXP * 0.2f;
        xpSlider.SetMaxValue(nextLevelXP);
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
}
