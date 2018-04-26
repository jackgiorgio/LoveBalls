using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleBall : MonoBehaviour {

    public Sprite idleFace, smilingFace, cryFace;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    public enum Face { idle, smile, cry };
}
