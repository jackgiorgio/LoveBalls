using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public Text moneyText;
    public Text shopTypeText;
    public ButtonState penShop, ballsShop, bgSkinShop ;

    private int money = 0;
    public int Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
            PlayerPrefsManager.SetMoney(money);
            moneyText.text = money.ToString();
        }
    }

            
 



    void Start() {
        Money = PlayerPrefsManager.GetMoney();
    }

    // Update is called once per frame
    void Update() {

    }

    public void BuyOrUsePen()
    {
        Pen pen = penShop.penAsset;
        if (PlayerPrefsManager.IsPenUnblocked(pen.index) == 0) //buy pen then
        {
            if (pen.price <= money)
            {
                Money -= pen.price;
                PlayerPrefsManager.UnblockPen(pen.index);
                penShop.LoadButtonState(pen);
            }
        }

        else if (PlayerPrefsManager.GetCurrentPen() != pen.index) //then use it;
        {
            PlayerPrefsManager.SetCurrentPen(pen.index);
            penShop.LoadButtonState(pen);
        }

    }

    void HideShopManager()
    {
        gameObject.SetActive(false);
    }

    public void BuyOrUseBallSkin()
    {
        BallSkin ballSkin= ballsShop.ballSkinAsset;
        if (PlayerPrefsManager.IsBallSkinUnblocked(ballSkin.index) == 0) //buy ball then
        {
            if (ballSkin.price <= money)
            {
                Money -= ballSkin.price;
                PlayerPrefsManager.UnblockBallSkin(ballSkin.index);
                ballsShop.LoadButtonState(ballSkin);
            }
        }

        else if (PlayerPrefsManager.GetCurrentBallSkin() != ballSkin.index) //then use it;
        {
            PlayerPrefsManager.SetCurrentBallSkin(ballSkin.index);
            ballsShop.LoadButtonState(ballSkin);
        }

    }

    public void BuyOrUseBGSkin()
    {
        BGSkin bgSkin = bgSkinShop.bgSkinAsset;
        if (PlayerPrefsManager.IsBGSkinUnblocked(bgSkin.index) == 0) //buy ball then
        {
            if (bgSkin.price <= money)
            {
                Money -= bgSkin.price;
                PlayerPrefsManager.UnblockBGSkin(bgSkin.index);
                bgSkinShop.LoadButtonState(bgSkin);
            }
        }

        else if (PlayerPrefsManager.GetCurrentBGSkin() != bgSkin.name) //then use it;
        {
            PlayerPrefsManager.SetCurrentBGSkin(bgSkin.index);
            bgSkinShop.LoadButtonState(bgSkin);
        }

    }

    public void ChangeShopTitle(string shopType)
    {
        shopTypeText.text = shopType;
    }
}
