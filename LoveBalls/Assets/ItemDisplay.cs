using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour {

    public Pen pen;
    Image penImage;
    private Vector3 initialScale;
    private Color color;

    void Start()
    {
        penImage = GetComponent<Image>();
        penImage.sprite = pen.penSprite;
        initialScale = gameObject.transform.localScale;
    }

    void Expand()
    {
        gameObject.transform.localScale = initialScale;
        penImage.color = Color.white;
        
        
    }

    void Shrink()
    {
        gameObject.transform.localScale = initialScale*0.8f;
        penImage.color = Color.grey;
    }
}
