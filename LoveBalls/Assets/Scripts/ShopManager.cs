using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public Text moneyText;
    public ButtonState buttonState;

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
        HideShopManager();
        Money = 2000;
    }

    // Update is called once per frame
    void Update() {

    }

    public void BuyOrUsePen()
    {
        Pen pen = buttonState.penAsset;
        if (PlayerPrefsManager.IsPenUnblocked(pen.index) == 0) //buy pen then
        {
            if (pen.price <= money)
            {
                Money -= pen.price;
                PlayerPrefsManager.UnblockPen(pen.index);
                buttonState.LoadButtonState(pen);
            }
        }

        else if (PlayerPrefsManager.GetCurrentPen() != pen.name) //then use it;
        {
            PlayerPrefsManager.SetCurrentPen(pen.index);
            buttonState.LoadButtonState(pen);
        }

    }

    void HideShopManager()
    {
        gameObject.SetActive(false);
    }
}
