using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool playerIsAlive;
    public float gameScore;

    Timer timer;

    private void Awake()
    {
        if(FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        AudioManager.instance.PlayAudioClip("Main Theme");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);

        if (AudioManager.instance.CheckIfPlaying("Main Theme") == false)
        {
            AudioManager.instance.PlayAudioClip("Main Theme");
        }

        StartTime();
        playerIsAlive = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        if (AudioManager.instance.CheckIfPlaying("Main Theme") == false)
        {
            AudioManager.instance.PlayAudioClip("Main Theme");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        ScoreKeeper scoreKeeper = FindObjectOfType<ScoreKeeper>();
        gameScore = scoreKeeper.GetScore();

        AudioManager.instance.StopAudioClip("Main Theme");
        playerIsAlive = false;

        SceneManager.LoadScene(2);
        AudioManager.instance.PlayAudioClip("Player Death SFX");
    }

    public void StartTime()
    {
        Time.timeScale = 1.0f;
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }
}
