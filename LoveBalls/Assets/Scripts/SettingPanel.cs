using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour {

    public Sprite musicOn, musicOff, voiceOn, voiceOff, vibrationOn, vibrationOff;
    public GameObject musicButton, voiceButton, vibrationButton;
    private MusicPlayer musicPlayer;
    

    
    // Use this for initialization
	void Start () {
        musicPlayer = MusicPlayer.instance;
        LoadMusicMode();
        LoadVoiceMode();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchMusicMode()
    {
        if (musicPlayer)
        {
            if (musicPlayer.isMute == true) //如果当前是静音，则打开声音
            {
                musicPlayer.UnMute("Start");
                musicPlayer.UnMute("Background");
                musicButton.GetComponent<Image>().sprite = musicOn;
                musicPlayer.isMute = false;
            }
            else
            {
                musicPlayer.SetMute("Start");
                musicPlayer.SetMute("Background");
                musicButton.GetComponent<Image>().sprite = musicOff;
                musicPlayer.isMute = true;
            }
        }
    }

    public void LoadMusicMode()
    {
        if (musicPlayer)
        {
            if (musicPlayer.isMute == false) //如果当前是静音，则打开声音
            {
                musicButton.GetComponent<Image>().sprite = musicOn;
            }
            else
            {
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
