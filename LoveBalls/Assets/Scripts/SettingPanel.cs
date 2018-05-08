using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour {

    public Sprite musicOn, musicOff, voiceOn, voiceOff, vibrationOn, vibrationOff;
    public GameObject musicButton, voiceButton, vibrationButton;
    private AudioSource audioSource;
    

    
    // Use this for initialization
	void Start () {
        if (GameObject.FindObjectOfType<AudioSource>())
        {
            audioSource = GameObject.FindObjectOfType<AudioSource>();
            Debug.Log("found audiosource!");
        }
        LoadMusicMode();
        LoadVoiceMode();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchMusicMode()
    {
        if (audioSource)
        {
            if (audioSource.mute == false)
            {
                audioSource.mute = true;
                musicButton.GetComponent<Image>().sprite = musicOff;
            }
            else
            {
                audioSource.mute = false;
                musicButton.GetComponent<Image>().sprite = musicOn;
            }
        }
    }

    public void LoadMusicMode()
    {
        if (audioSource)
        {
            if (audioSource.mute == false)
            {
                audioSource.mute = false;
                musicButton.GetComponent<Image>().sprite = musicOn;
            }
            else
            {
                audioSource.mute = true;
                musicButton.GetComponent<Image>().sprite = musicOff;
            }
        }
    }

    public void SwitchVoiceMode()
    {
        if (PlayerPrefsManager.IsSoundEffectOn())
        {
            voiceButton.GetComponent<Image>().sprite = voiceOff;
        }
        else
        {
            voiceButton.GetComponent<Image>().sprite = voiceOn;
        }
        PlayerPrefsManager.SwitchSoundEffect();
    }

    public void LoadVoiceMode()
    {
        if (PlayerPrefsManager.IsSoundEffectOn())
        {
            voiceButton.GetComponent<Image>().sprite = voiceOn;
        }
        else
        {
            voiceButton.GetComponent<Image>().sprite = voiceOff;
        }
    }


    public void ShowOrHideSettingMode()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }



}
