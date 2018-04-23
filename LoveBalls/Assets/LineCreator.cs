using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour {

    public GameObject linePrefab;


    Line activeLine;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject lineGo = Instantiate(linePrefab);
            activeLine = lineGo.GetComponentInChildren<Line>();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Rigidbody2D rb = activeLine.transform.GetComponentInParent<Rigidbody2D>();
            rb.isKinematic = false;
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
	}
}
