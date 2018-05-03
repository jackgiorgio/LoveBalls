using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    const string SOUNDSEFECT = "soundeffect"; 

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("master volume out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnblockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(),1);
        }
        else
        {
            Debug.LogError("trying of unblock level not in build order");
        }

    }

    public static bool IsLevelUnblocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnblocked = (levelValue == 1);
        if (level <= SceneManager.sceneCountInBuildSettings - 4)
        {
            return isLevelUnblocked;
        }
        else {
            Debug.LogError("trying of unblock level not in build order");
            return false;
        }
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 0f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("difficulty out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }


    public static void SwitchSoundEffect()
    {
        if (PlayerPrefs.GetInt(SOUNDSEFECT) == 1)
        {
            PlayerPrefs.SetInt(SOUNDSEFECT, 0);
        }
        else
        {
            PlayerPrefs.SetInt(SOUNDSEFECT, 1);
        }
    }

    public static bool IsSoundEffectOn()
    {
        bool isOn;
        //1 for On and 0 for Off
        isOn = PlayerPrefs.GetInt(SOUNDSEFECT) == 1;
        return isOn;
    }

}
