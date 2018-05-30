using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Percentage : MonoBehaviour {

    Image image;
	
    // Use this for initialization
	void Start () {

        image = GetComponent<Image>();
        FillWithPersentage(1f);
		
	}

    public void FillWithPersentage(float percentage)
    {
        if (percentage <= 1 && percentage >= 0)
        {
            image.fillAmount = percentage;
        }
    }

}
