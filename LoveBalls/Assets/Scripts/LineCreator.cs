﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour {

    public GameObject linePrefab;
    public GameObject lineParent;
    Line activeLine;


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject lineGo = Instantiate(linePrefab);
            activeLine = lineGo.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameObject lineP = Instantiate(lineParent,activeLine.NewCenterOfMass(),Quaternion.identity);
            activeLine.gameObject.transform.SetParent(lineP.transform);
            activeLine = null;

        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
	}
}
