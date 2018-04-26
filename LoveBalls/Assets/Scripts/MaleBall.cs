using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaleBall : MonoBehaviour {

    public Sprite idleFace, smilingFace, cryFace;
    private SpriteRenderer spriteRenderer;

    private GameObject female;

    private GameManager gameManager;

    private bool triggerWinCondition;

	void Start () {
        female = GameObject.FindGameObjectWithTag("Female");
        gameManager = GameManager.FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Female")
        {
            gameManager.isLevelPassed = true;
            ResetToKinematic();
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

    public void ChangeFace(Face face)
    {
        if (face == Face.smile)
        {
            spriteRenderer.sprite = smilingFace;
        }

        if (face == Face.idle)
        {
            spriteRenderer.sprite = idleFace;
        }

        if (face == Face.cry)
        {
            spriteRenderer.sprite = cryFace;
        }

    }

    public enum Face { idle,smile,cry};




}
