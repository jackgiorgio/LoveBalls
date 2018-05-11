using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGSkinDisplay : MonoBehaviour
{

    public BGSkin bgSkin;
    Image bgImage;
    private Vector3 initialScale;
    private Color color;

    void Start()
    {
        bgImage = GetComponent<Image>();
        bgImage.sprite = bgSkin.sprite;
        initialScale = gameObject.transform.localScale;
    }

    void Expand()
    {
        gameObject.transform.localScale = initialScale;
        bgImage.color = Color.white;


    }

    void Shrink()
    {
        gameObject.transform.localScale = initialScale * 0.8f;
        bgImage.color = Color.grey;
    }

}
