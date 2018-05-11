using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentageText : MonoBehaviour {

    private Text percentageText;
    
    // Use this for initialization
	void Start () {
        percentageText = GetComponent<Text>();
	}

    public void ShowPercentage(float percentage)
    {
        percentageText.text = ((int)(percentage * 100)).ToString() + "%";
    }
}
