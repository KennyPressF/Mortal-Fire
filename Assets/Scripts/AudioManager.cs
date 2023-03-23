using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        SetUpSingleton();
        InitializeAudioComponents();
    }

    private void SetUpSingleton()
    {
        if (instance == null)
        {
            instance= this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void InitializeAudioComponents()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.outputAudioMixerGroup = s.group;
            s.source.playOnAwake = s.playOnAwake;
            s.source.loop = s.loop;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void PlayAudioClip(string clipName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == clipName);
        if (s == null)
        {
            Debug.Log("Can't find audio clip. Is there a typo?");
            return;
        }
        s.source.Play();
    }

    public void StopAudioClip(string clipName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == clipName);
        if (s == null)
        {
            Debug.Log("Can't find audio clip. Is there a typo?");
            return;
        }
        s.source.Stop();
    }

    public bool CheckIfPlaying(string clipName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == clipName);
        if (s.source.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
