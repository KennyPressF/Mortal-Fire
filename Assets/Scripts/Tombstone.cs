using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tombstone : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    int score;
    int highScore;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        score = Mathf.CeilToInt(gameManager.gameScore);
        CheckForHighScore();
        UpdateHighScore();
        DisplayRecentScore();
        DisplayHighScore();
    }

    private void CheckForHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highScore = 0;
        }
    }

    private void UpdateHighScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    private void DisplayRecentScore()
    {
        scoreText.text = "Score:\n" + score.ToString();
    }
    
    private void DisplayHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "High Score:\n" + highScore.ToString();
    }
}
