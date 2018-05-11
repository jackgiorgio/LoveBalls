using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallsDisplay : MonoBehaviour {

    public BallSkin ballskin;
    Image ballImage;
    private Vector3 initialScale;
    private Color color;

    void Start()
    {
        ballImage = GetComponent<Image>();
        ballImage.sprite = ballskin.sprite;
        initialScale = gameObject.transform.localScale;
    }

    void Expand()
    {
        gameObject.transform.localScale = initialScale;
        ballImage.color = Color.white;


    }

    void Shrink()
    {
        gameObject.transform.localScale = initialScale * 0.8f;
        ballImage.color = Color.grey;
    }

}
