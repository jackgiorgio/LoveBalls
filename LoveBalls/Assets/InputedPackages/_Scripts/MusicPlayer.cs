using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    static MusicPlayer instance = null;


    public AudioClip[] levelMusicChangeArray;
    private AudioSource music;
    //singleton

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);

            print("Duplicate music player self-destructing!");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.clip = levelMusicChangeArray[0];
            music.loop = false;
            music.Play();
        }
    }

    void Start()
    {
        music.volume = PlayerPrefsManager.GetMasterVolume();
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
        AudioClip thisLevelMusic = levelMusicChangeArray[level];
        if (thisLevelMusic)
        {
            music.clip = thisLevelMusic;
            if (level == 0)
            {
                music.loop = true;
            }
            else
            {
                music.loop = false;
            }
            music.Play();
        }
    }

    public void SetVolume(float volume)
    {
        music.volume = volume;
    }



}