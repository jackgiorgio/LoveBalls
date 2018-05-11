using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    public LineRenderer lineRenderer;
    public SpriteRenderer penSkin;
    public GameObject pen;
    public Sprite[] penSkins;
    public EdgeCollider2D edgeCol;
    List<Vector2> points;
    public PenColorPreset[] colorPresets;


    // Use this for initialization
    void Start() {
        SetPenSkin();
        SetLineColor();
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

        pen.transform.position = new Vector3(point.x,point.y,0);


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

    public float LineDistance()
    {
        float lineDistance = 0;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
           if (i > 1)
           {
                    Vector2 formerPos = lineRenderer.GetPosition(i - 1);
                    Vector2 latterPos = lineRenderer.GetPosition(i);
                    float distance = Vector2.Distance(formerPos, latterPos);
                    lineDistance += distance;
                }
            }
        return lineDistance;
    }


    public void SetPenSkin()
    {
        int currentPenIndex = PlayerPrefsManager.GetCurrentPen();
        penSkin.sprite = penSkins[currentPenIndex - 1];
    }

    public void DiattivatePen()
    {
        pen.SetActive(false);
    }

    public void SetLineColor()
    {
        int currentPenIndex = PlayerPrefsManager.GetCurrentPen();
        lineRenderer.colorGradient = colorPresets[currentPenIndex - 1].colorGradient;
    }
}
