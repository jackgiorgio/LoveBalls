using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider, diffSlider;
    public LevelManager levelManager;
    public MusicPlayer musicPlayer;


	// Use this for initialization
	void Start () {
        musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        diffSlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
        musicPlayer.SetVolume(volumeSlider.value);

	}

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(diffSlider.value);
        levelManager.LoadLevel("Start");
    }

    public void SetDefault()
    {
        volumeSlider.value = 0.7f;
        diffSlider.value = 2f;
    }
}
