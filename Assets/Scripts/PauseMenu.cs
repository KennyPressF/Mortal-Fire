using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        pausePanel.SetActive(false);

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SetMusicVolume(musicSlider.value);

        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetSFXVolume(sfxSlider.value);
    }

    public void TogglePausePanel()
    {
        if (Time.timeScale == 1.0f) { Time.timeScale = 0f; }
        else { Time.timeScale = 1.0f; }
        pausePanel.SetActive(!pausePanel.activeSelf);
    }

    public void ExitCurrentGame()
    {
        Time.timeScale = 1.0f;
        gameManager.LoadMainMenu();
    }

    public void SetMusicVolume(float volume)
    {
        if (musicSlider.value < -19)
        {
            audioMixer.SetFloat("MusicVolume", -80);
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", volume);
        }
        SetPPrefMusic(volume);
    }

    public void SetSFXVolume(float volume)
    {
        if (sfxSlider.value < -19)
        {
            audioMixer.SetFloat("SFXVolume", -80);
        }
        else
        {
            audioMixer.SetFloat("SFXVolume", volume);
        }
        SetPPrefSFX(volume);
    }

    private void SetPPrefMusic(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    private void SetPPrefSFX(float value)
    {
        PlayerPrefs.SetFloat("SFXVolume", value);
    }
}
