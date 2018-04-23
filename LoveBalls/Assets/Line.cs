using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCol;

    List<Vector2> points;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    public void UpdateLine(Vector2 mousePos)  // 将鼠标位置加入list<Vector2> points
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }

        if (Vector2.Distance(points.Last(), mousePos)> .1f)
        {
            SetPoint(mousePos);
        }
            

        //Check if the mouse has move enough for us to insert new point
        //if it has: Insert point at mouse position
    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);


        if (points.Count > 1)
        {          
            edgeCol.points = points.ToArray();
        }
    }
}
