using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaleBall : MonoBehaviour {

    public Sprite idleFace, smilingFace, cryFace;
    public Sprite[] skins;
    public SpriteRenderer face;
    public SpriteRenderer skin;

    private GameObject female;

    private GameManager gameManager;

    private bool triggerWinCondition = false;

	void Start () {
        female = GameObject.FindGameObjectWithTag("Female");
        gameManager = FindObjectOfType<GameManager>();
        ChangeSkin();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Female" & triggerWinCondition ==false)
        {
            gameManager.isLevelPassed = true;
            ResetToKinematic();
            triggerWinCondition = true;
        }
    }

    void ResetToKinematic()
    {
        Rigidbody2D rbMale = GetComponent<Rigidbody2D>();
        rbMale.Sleep();
        rbMale.isKinematic = true;
        Rigidbody2D rbFemale = female.GetComponent<Rigidbody2D>();
        rbFemale.Sleep();
        rbFemale.isKinematic = true;
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

    public enum Face { idle,smile,cry};

    void ChangeSkin()
    {
        int currentSkinIndex = PlayerPrefsManager.GetCurrentBallSkin();
        skin.sprite = skins[currentSkinIndex-1];

    }




}
