﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour {

    public GameObject linePrefab;
    public GameObject lineParent;
    public float lineDistance;
    Line activeLine;

    private GameManager gameManager;


    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            gameManager.CaptureDefaultScreenShot();
            GameObject lineGo = Instantiate(linePrefab);
            activeLine = lineGo.GetComponent<Line>();

        }

        if (Input.GetMouseButton(0))
        {
            lineDistance = activeLine.LineDistance();
            gameManager.TotalDistance = gameManager.previousDistance + lineDistance;
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameObject lineP = Instantiate(lineParent,activeLine.NewCenterOfMass(),Quaternion.identity);
            activeLine.gameObject.transform.SetParent(lineP.transform);
            gameManager.previousDistance = gameManager.TotalDistance;
            activeLine.DiattivatePen();
            activeLine = null;
            if (gameManager.gameStarted == false)
            {
                gameManager.SetFreeBalls();
            }

        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
            
        }
	}

    public void Disable()
    {
        Destroy(gameObject);
    }

}
