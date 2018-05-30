using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    const int levelAmount = 132;
    const int skinAmount = 9;

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    const string SOUNDSEFECT = "soundeffect";
    const string MONEY = "money";
    const string PEN = "pen";
    const string BALLS = "balls";
    const string BGSKIN = "bgSkin";
    const string CURRERNTPEN = "using_pen";
    const string CURRERNTBALLSKIN = "using_ball_skin";
    const string CURRERNTBGSKIN = "using_bg_skin";
    const string LEVELSTAR = "star_of_level_";
    const string CURRENTBGMUSIC = "current_background_music";
    const string TOTALSTAR = "totalStar";
    const string TOTALLEVEL = "totalLevel";


    private void Start()
    {
        PlayerPrefs.SetInt(TOTALLEVEL, levelAmount);
        ResetPlayerPref();
        UpdateUnblockedLevels();
        ResetSkins();
    }


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
        return isLevelUnblocked;
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

    public static int IsPenUnblocked(int penIndex)
    {
        if (penIndex < 10)
        {
            return PlayerPrefs.GetInt(PEN + "00" + penIndex.ToString());
        }
        if (penIndex >= 10 && penIndex < 100)
        {
            return PlayerPrefs.GetInt(PEN + "0" + penIndex.ToString());
        }
        else
        {
            return PlayerPrefs.GetInt(PEN + penIndex.ToString());
        }
    }

    public static void UnblockPen(int penOrder)
    {
        if (penOrder < 10)
        {
            PlayerPrefs.SetInt(PEN + "00" + penOrder.ToString(), 1);
            return;
        }
        if (penOrder >= 10 && penOrder < 100)
        {
            PlayerPrefs.GetInt(PEN + "0" + penOrder.ToString(), 1);
        }
        else
        {
            PlayerPrefs.GetInt(PEN + penOrder.ToString(), 1);
        }
    }

    public static int GetCurrentPen()
    {
        return PlayerPrefs.GetInt(CURRERNTPEN);
    }

    public static void SetCurrentPen(int penIndex)
    {
        PlayerPrefs.SetInt(CURRERNTPEN, penIndex);
    }

    public static int IsBallSkinUnblocked(int ballSkinIndex)
    {
        if (ballSkinIndex < 10)
        {
            return PlayerPrefs.GetInt(BALLS + "00" + ballSkinIndex.ToString());
        }
        if (ballSkinIndex >= 10 && ballSkinIndex < 100)
        {
            return PlayerPrefs.GetInt(BALLS + "0" + ballSkinIndex.ToString());
        }
        else
        {
            return PlayerPrefs.GetInt(BALLS + ballSkinIndex.ToString());
        }
    }

    public static void UnblockBallSkin(int ballsIndex)
    {
        if (ballsIndex < 10)
        {
            PlayerPrefs.SetInt(BALLS + "00" + ballsIndex.ToString(), 1);
            return;
        }
        if (ballsIndex >= 10 && ballsIndex < 100)
        {
            PlayerPrefs.SetInt(BALLS + "0" + ballsIndex.ToString(), 1);
        }
        else
        {
            PlayerPrefs.SetInt(BALLS + ballsIndex.ToString(), 1);
        }
    }

    public static int GetCurrentBallSkin()
    {
        return PlayerPrefs.GetInt(CURRERNTBALLSKIN);
    }

    public static void SetCurrentBallSkin(int ballSkinIndex)
    {
        PlayerPrefs.SetInt(CURRERNTBALLSKIN, ballSkinIndex);
    }

    public static int IsBGSkinUnblocked(int bgSkinIndex)
    {
        if (bgSkinIndex < 10)
        {
            return PlayerPrefs.GetInt(BGSKIN + "00" + bgSkinIndex.ToString());
        }
        if (bgSkinIndex >= 10 && bgSkinIndex < 100)
        {
            return PlayerPrefs.GetInt(BGSKIN + "0" + bgSkinIndex.ToString());
        }
        else
        {
            return PlayerPrefs.GetInt(BGSKIN + bgSkinIndex.ToString());
        }
    }

    public static void UnblockBGSkin(int bgSkinIndex)
    {
        if (bgSkinIndex < 10)
        {
            PlayerPrefs.SetInt(BGSKIN + "00" + bgSkinIndex.ToString(), 1);
            return;
        }
        if (bgSkinIndex >= 10 && bgSkinIndex < 100)
        {
            PlayerPrefs.SetInt(BGSKIN + "0" + bgSkinIndex.ToString(), 1);
        }
        else
        {
            PlayerPrefs.SetInt(BGSKIN + bgSkinIndex.ToString(), 1);
        }
    }

    public static int GetCurrentBGSkin()
    {
        return PlayerPrefs.GetInt(CURRERNTBGSKIN);
    }

    public static void SetCurrentBGSkin(int bgSkinIndex)
    {
        PlayerPrefs.SetInt(CURRERNTBGSKIN, bgSkinIndex);
    }

    public static int GetLevelStar(int levelIndex)
    {
        return PlayerPrefs.GetInt(LEVELSTAR + levelIndex.ToString());
    }

    public static void SetUnblockStar(int levelIndex, int star)
    {
        if (star > PlayerPrefs.GetInt(LEVELSTAR + levelIndex.ToString()))
        {
            PlayerPrefs.SetInt(LEVELSTAR + levelIndex.ToString(), star);
        }
    }

    public static void SetCurrentBGMusic(string musicName)
    {
        PlayerPrefs.SetString(CURRENTBGMUSIC,musicName);
    }

    public static string GetCurrentBGMusic()
    {
        return PlayerPrefs.GetString(CURRENTBGMUSIC);
    }

    public static int GetTotalLevel()
    {
        return PlayerPrefs.GetInt(TOTALLEVEL);
    }



    public void ResetPlayerPref()
    {
        if (!PlayerPrefs.HasKey(CURRERNTPEN))
        {
            PlayerPrefs.SetInt(CURRERNTPEN, 1);
        }
        if (!PlayerPrefs.HasKey(CURRERNTBGSKIN))
        {
            PlayerPrefs.SetInt(CURRERNTBGSKIN, 1);
        }
        if (!PlayerPrefs.HasKey(CURRERNTBALLSKIN))
        {
            PlayerPrefs.SetInt(CURRERNTBALLSKIN, 1);
        }
        if (!PlayerPrefs.HasKey(CURRERNTBALLSKIN))
        {
            PlayerPrefs.SetInt(CURRERNTBALLSKIN, 1);
        }
        LoadLevelsData(levelAmount);
        SetTotalStars();
        if (!PlayerPrefs.HasKey(MONEY))
        {
            PlayerPrefs.SetInt(MONEY, 800);
        }


    }

    void LoadLevelsData(int totalLevel)    //
    {
        for (int i = 0; i < totalLevel; i++)
        {
            string levelStar = LEVELSTAR + (i+1).ToString();
            if (!PlayerPrefs.HasKey(levelStar))
            {
                    PlayerPrefs.SetInt(levelStar, 0);
            }
        }

        for (int i = 0; i < totalLevel; i++)
        {
            string level_key = LEVEL_KEY + (i + 1).ToString();
            if (!PlayerPrefs.HasKey(level_key))
            {
                if (i == 0)
                {
                    PlayerPrefs.SetInt(level_key, 1);
                }
                else
                {
                    PlayerPrefs.SetInt(level_key, 0);
                }
            }
        }
    }

    public static int GetTotalStar()
    {
        return PlayerPrefs.GetInt(TOTALSTAR);
    }


    public static void SetTotalStars()
    {
        int totalStar = 0;
        for (int i = 1; i < PlayerPrefsManager.GetTotalLevel()+1; i++)
        {
            totalStar += PlayerPrefsManager.GetLevelStar(i);
        }
        PlayerPrefs.SetInt(TOTALSTAR, totalStar);
        Debug.Log(totalStar.ToString() + " stars in total");
    }

    public static void UpdateUnblockedLevels()
    {
        int totalLevel = PlayerPrefsManager.GetTotalLevel();
        int totalStar = PlayerPrefsManager.GetTotalStar();
        for (int i = 1; i < totalLevel+1; i++)
        {
            if (i<25)
            {
                PlayerPrefs.SetInt(LEVEL_KEY + i.ToString(), 1);
            }
            else if (i>=25)
            {
                if (totalStar >= (10 + 30 * (i / 12 - 1)))
                {
                    PlayerPrefs.SetInt(LEVEL_KEY + i.ToString(), 1);
                }
                else
                {
                    PlayerPrefs.SetInt(LEVEL_KEY + i.ToString(), 0);
                }
            }
        } 
    }

    void ResetSkins()
    {
        for (int i = 1; i < skinAmount+1; i++)
        {
            if (i == 1)
            {
                PlayerPrefs.SetInt(PEN + "00" + i.ToString(), 1);

            }
            else if (!PlayerPrefs.HasKey(PEN+"00"+i.ToString()))
            {
                PlayerPrefs.SetInt(PEN + "00" + i.ToString(), 0);
            }
        }

        for (int i = 1; i < skinAmount + 1; i++)
        {
            if (i == 1)
            {
                PlayerPrefs.SetInt(BGSKIN + "00" + i.ToString(), 1);

            }
            else if (!PlayerPrefs.HasKey(BGSKIN + "00" + i.ToString()))
            {
                PlayerPrefs.SetInt(BGSKIN + "00" + i.ToString(), 0);
            }
        }

        for (int i = 1; i < skinAmount + 1; i++)
        {
            if (i == 1)
            {
                PlayerPrefs.SetInt(BALLS + "00" + i.ToString(), 1);

            }
            else if (!PlayerPrefs.HasKey(BALLS + "00" + i.ToString()))
            {
                PlayerPrefs.SetInt(BALLS + "00" + i.ToString(), 0);
            }
        }

    }


}
