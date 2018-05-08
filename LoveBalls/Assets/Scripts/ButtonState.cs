using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour {

    public Button stateButton;
    public Text stateText;
    private Image stateImage;
    public Image bgImage;

    public Pen penAsset;
    public BGSkin bgSkinAsset;
    public BallSkin ballSkinAsset;
    public GameObject coin;
    public Sprite greyBG;
    public Sprite greenBG;
    public Sprite yellowBG;
    
    // Use this for initialization
	void Start () {
        stateButton = GetComponent<Button>();
        //stateText = GetComponentInChildren<Text>();
        //bgImage = GetComponent<Image>();
        penAsset = ScriptableObject.CreateInstance<Pen>();
        ballSkinAsset = ScriptableObject.CreateInstance<BallSkin>();
        bgSkinAsset = ScriptableObject.CreateInstance<BGSkin>();


    }

    public void LoadButtonState(Pen pen)
    {
        if (PlayerPrefsManager.IsPenUnblocked(pen.index) == 1)
        {
            if (PlayerPrefsManager.GetCurrentPen() == pen.name)
            {
                stateText.text = "Using";
                coin.SetActive(false);
                bgImage.sprite = greyBG;
                stateButton.interactable = false;
                GetCurrentPen(pen);


            }
            else
            {
                stateText.text = "Use";
                coin.SetActive(false);
                bgImage.sprite = yellowBG;
                stateButton.interactable = true;
                GetCurrentPen(pen);
            }
        }
        else
        {
            stateText.text = pen.price.ToString();
            coin.SetActive(true);
            bgImage.sprite = greenBG;
            stateButton.interactable = true;
            GetCurrentPen(pen);
        }
    }

    public void LoadButtonState(BallSkin ballskin)
    {
        if (PlayerPrefsManager.IsBallSkinUnblocked(ballskin.index) == 1)
        {
            if (PlayerPrefsManager.GetCurrentBallSkin() == ballskin.name)
            {
                stateText.text = "Using";
                coin.SetActive(false);
                bgImage.sprite = greyBG;
                stateButton.interactable = false;
                GetCurrentBallSkin(ballskin);
            }
            else
            {
                stateText.text = "Use";
                coin.SetActive(false);
                bgImage.sprite = yellowBG;
                stateButton.interactable = true;
                GetCurrentBallSkin(ballskin);
            }
        }
        else
        {
            stateText.text = ballskin.price.ToString();
            coin.SetActive(true);
            bgImage.sprite = greenBG;
            stateButton.interactable = true;
            GetCurrentBallSkin(ballskin);
        }
    }

    public void LoadButtonState(BGSkin bgSkin)
    {
        if (PlayerPrefsManager.IsBGSkinUnblocked(bgSkin.index) == 1)
        {
            if (PlayerPrefsManager.GetCurrentBGSkin() == bgSkin.name)
            {
                stateText.text = "Using";
                coin.SetActive(false);
                bgImage.sprite = greyBG;
                stateButton.interactable = false;
                GetCurrentBGSkin(bgSkin);


            }
            else
            {
                stateText.text = "Use";
                coin.SetActive(false);
                bgImage.sprite = yellowBG;
                stateButton.interactable = true;
                GetCurrentBGSkin(bgSkin);
            }
        }
        else
        {
            stateText.text = bgSkin.price.ToString();
            coin.SetActive(true);
            bgImage.sprite = greenBG;
            stateButton.interactable = true;
            GetCurrentBGSkin(bgSkin);
        }
    }



    public void GetCurrentPen(Pen pen)
    {
        penAsset = ScriptableObject.CreateInstance<Pen>();
        penAsset.name = pen.name;
        penAsset.price = pen.price;
        penAsset.index = pen.index;
        penAsset.sprite = pen.sprite;
    }

    public void GetCurrentBallSkin(BallSkin ballSkin)
    {
        ballSkinAsset = ScriptableObject.CreateInstance<BallSkin>();
        ballSkinAsset.name = ballSkin.name;
        ballSkinAsset.price = ballSkin.price;
        ballSkinAsset.index = ballSkin.index;
        ballSkinAsset.sprite = ballSkin.sprite;
    }

    public void GetCurrentBGSkin(BGSkin bgSkin)
    {
        bgSkinAsset = ScriptableObject.CreateInstance<BGSkin>();
        bgSkinAsset.name = bgSkin.name;
        bgSkinAsset.price = bgSkin.price;
        bgSkinAsset.index = bgSkin.index;
        bgSkinAsset.sprite = bgSkin.sprite;
    }




}
