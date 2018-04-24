using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public GameObject defenderPrefeb;
    private Button[] buttonArray;
    public static GameObject selectedDefender;
    private Text costText;

    void Start()
    {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogError("missing costText of" + name);
        }
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }

        costText.text = defenderPrefeb.GetComponent<Defender>().sunCost.ToString();
        
    }


    void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefeb;
    }
}
