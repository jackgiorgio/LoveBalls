using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundDisplay : MonoBehaviour {

     public Sprite[] skins;
     public SpriteRenderer skin;
    // Use this for initialization
    void Start () {
        ChangeSkin();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChangeSkin()
    {
        int currentSkinIndex = PlayerPrefsManager.GetCurrentBGSkin();
        skin.sprite = skins[currentSkinIndex - 1];

    }
}
