using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleBall : MonoBehaviour {

    public Sprite idleFace, smilingFace, cryFace;
    public SpriteRenderer face,skin;
    public Sprite[] skins;

    void Start()
    {
        ChangeSkin();
    }

    public void ChangeFace(Face faceState)
    {
        if (faceState == Face.smile)
        {
            face.sprite = smilingFace;
        }

        if (faceState == Face.idle)
        {
            face.sprite = idleFace;
        }

        if (faceState == Face.cry)
        {
            face.sprite = cryFace;
        }

    }

    public enum Face { idle, smile, cry };


    void ChangeSkin()
    {
        int currentSkinIndex = PlayerPrefsManager.GetCurrentBallSkin();
        skin.sprite = skins[currentSkinIndex - 1];

    }
}
