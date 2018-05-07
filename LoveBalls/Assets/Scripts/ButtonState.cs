using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour {

    private Button stateButton;
    private Text stateText;
    private Image stateImage;
    private Image bgImage;
    public Pen penAsset;

    public GameObject coin;
    public Sprite greyBG;
    public Sprite greenBG;
    public Sprite yellowBG;
    
    // Use this for initialization
	void Start () {
        stateButton = GetComponent<Button>();
        stateText = GetComponentInChildren<Text>();
        bgImage = GetComponent<Image>();

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
            {;
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

    public void GetCurrentPen(Pen pen)
    {
        penAsset = new Pen();
        penAsset.name = pen.name;
        penAsset.price = pen.price;
        penAsset.index = pen.index;
        penAsset.penSprite = pen.penSprite;
    }



    
}
