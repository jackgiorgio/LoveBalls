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

    public void UpdateLine(Vector2 mousePos) //drawnew line 
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

    public Vector2 NewCenterOfMass()
    {
        float totalx = 0;
        float totaly = 0;
        foreach (Vector2 point in points)
        {
            totalx += point.x;
            totaly += point.y;
        }
        Vector2 centerPoint = new Vector2(totalx / points.Count, totaly / points.Count);
        return centerPoint;
    }
}
