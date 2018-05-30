using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LevelDisplay : MonoBehaviour {

    public GameObject star1, star2, star3,lockPanel;
    public Text levelText;
    public int level;
    public Image screenshot;
    public Sprite defaultSprite;
    private IMG2Sprite iMG2Sprite;

    Texture2D texture;

    private Button levelButton;

    void Start () {
        iMG2Sprite = IMG2Sprite.instance;
        texture = new Texture2D(576, 320, TextureFormat.RGB24, false);
        levelButton = GetComponentInChildren<Button>();
        UpdateStarState();
        UpdateLockState();
        UpdateLevelText();
        UpdateScreenShot();

    }

    void UpdateStarState()
    {
        int star = PlayerPrefsManager.GetLevelStar(level);
        if (star > 0)
        { star1.SetActive(true); }
        if (star > 1)
        { star2.SetActive(true); }
        if (star > 2)
        { star3.SetActive(true); }
    }

    void UpdateLockState()
    {
        if (PlayerPrefsManager.IsLevelUnblocked(level))
        {
            lockPanel.SetActive(false);
            levelButton.interactable = true;
        }
        else
        {
            lockPanel.SetActive(true);
            levelButton.interactable = false;
        }
    }

    void UpdateLevelText()
    {
        if (level < 10)
        {
            levelText.text = "0" + level.ToString();
        }
        else
        {
            levelText.text = level.ToString();
        }
    }

    void UpdateScreenShot()
    {
        if (PlayerPrefsManager.GetLevelStar(level) == 0)
        {
            LoadDefaultTexture2D();
        }
        else
        {
            LoadLevelPassTexture2D();
        }
    }

    void LoadDefaultTexture2D()
    {
        string filePath = Application.persistentDataPath + "/Default_" + level.ToString() + ".png";
        if (File.Exists(filePath))
        {
            //screenshot.sprite = (Sprite)Resources.Load<Sprite>("LevelScreenshots/Default_" + level.ToString()) as Sprite;
            screenshot.sprite = iMG2Sprite.LoadNewSprite(filePath);
        }
        else
        {
            screenshot.sprite = defaultSprite;
        }
    }

    void LoadLevelPassTexture2D()
    {
        string filePath = Application.persistentDataPath + "/Screenshot_" + level.ToString() + ".png";
        if (File.Exists(filePath))
        {
            //screenshot.sprite = (Sprite)Resources.Load<Sprite>("LevelScreenshots/Screenshot_" + level.ToString()) as Sprite;
            screenshot.sprite = iMG2Sprite.LoadNewSprite(filePath);
        }
    }
}
