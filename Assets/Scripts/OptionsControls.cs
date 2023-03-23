using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsControls : MonoBehaviour
{
    [SerializeField] GameObject optionsPanel;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    [SerializeField] AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(false);

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SetMusicVolume(musicSlider.value);

        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetSFXVolume(sfxSlider.value);
    }

    public void ToggleOptionsPanel()
    {
        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }

    public void SetMusicVolume(float volume)
    {
        if(musicSlider.value < -19)
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
