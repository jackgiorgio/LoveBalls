using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    const string SOUNDSEFECT = "soundeffect";
    const string MONEY = "money";
    const string PEN = "pen";
    const string CURRERNTPEN = "using_pen_";

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
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
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
        else
        {
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

    public static int GetMoney()
    {
        return PlayerPrefs.GetInt(MONEY);
    }

    public static void SetMoney(int money)
    {
        PlayerPrefs.SetInt(MONEY, money);
    }

    public static int IsPenUnblocked(int penOrder)
    {
        if (penOrder < 10)
        { return PlayerPrefs.GetInt(PEN + "00" + penOrder.ToString()); }
        if (penOrder >= 10 && penOrder < 100)
        {
            return PlayerPrefs.GetInt(PEN + "0" + penOrder.ToString());
        }
        else
        {
            return PlayerPrefs.GetInt(PEN + penOrder.ToString());
        }
    }

    public static void UnblockPen(int penOrder)
    {
        if (penOrder < 10)
        {
            PlayerPrefs.SetInt(PEN + "00" + penOrder.ToString(), 1);
            if (penOrder >= 10 && penOrder < 100)
            {
                PlayerPrefs.GetInt(PEN + "0" + penOrder.ToString(), 1);
            }
            else
            {
                PlayerPrefs.GetInt(PEN + penOrder.ToString(), 1);
            }
        }
    }

    public static string GetCurrentPen()
    {
        return PlayerPrefs.GetString(CURRERNTPEN);
    }

    public static void SetCurrentPen(int penIndex)
    {
        PlayerPrefs.SetString(CURRERNTPEN, "pen00" + penIndex.ToString());
    }

}
