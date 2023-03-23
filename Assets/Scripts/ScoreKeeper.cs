using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    float currentScore;
    float pointIncreasePerSecond = 1f;
    TextMeshProUGUI scoreText;

    Timer timer;

    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        currentScore = 0;
    }

    private void FixedUpdate()
    {
        if (timer.keepTime)
        {
            currentScore += pointIncreasePerSecond * Time.fixedDeltaTime;
        }
        scoreText.text = currentScore.ToString("0000000");
    }

    public void AddToScore(float scoreValue)
    {
        currentScore += scoreValue;
    }

    public float GetScore()
    {
        return currentScore;
    }
}
