using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StarDisapper : MonoBehaviour {

    public float durantion = 2f;
    private Image image;
    public Vector3 disappearOffset;
    private bool isActivated = false;
    


    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void Disapplear()
    {
        if (isActivated == false)
        {
            transform.DOMove(transform.position + disappearOffset, durantion, false);
            image.DOFade(0, durantion);
            isActivated = true;
        }
        
    }
}
