using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
//using UnityEditor;

public class MusicPlayer : MonoBehaviour
{
    public Sound[] sounds;

    public static MusicPlayer instance;
    public bool isMute;


    //public AudioClip[] levelMusicChangeArray;
    //private AudioSource music;


    void Awake()  //singleton
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    private void Start()
    {
        StartPlayingMusic();
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        if (level == 1)
        {
            Play("Start");
            Stop("Background");
            PlayerPrefsManager.SetCurrentBGMusic("Start");
        }
        if (level > 1)
        {
            if (PlayerPrefsManager.GetCurrentBGMusic() != "Background")
            {
                Play("Background");
                PlayerPrefsManager.SetCurrentBGMusic("Background");
            }
        }

    }

    //public void SetVolume(float volume)
    //{
    //    music.volume = volume;
    //}

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    public void SetMute(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.mute = true;
    }

    public void UnMute(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.mute = false;
    }

    public void PlaySoundEffect(string name)
    {
        if (PlayerPrefsManager.IsSoundEffectOn())
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }
            s.source.Play();
        }
    }

    void StartPlayingMusic()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        if (level == 1)
        {
            Play("Start");
            Stop("Background");
            PlayerPrefsManager.SetCurrentBGMusic("Start");
        }
        if (level > 1)
        {
            if (PlayerPrefsManager.GetCurrentBGMusic() != "Background")
            {
                Play("Background");
                PlayerPrefsManager.SetCurrentBGMusic("Background");
            }
        }
    }





}