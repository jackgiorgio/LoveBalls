using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;

    private GameObject parent;
    private SunDisplay sundisplay;

    void Start()
    {

        parent = GameObject.Find("Defenders");
        sundisplay = GameObject.FindObjectOfType<SunDisplay>();

        if (!parent) {
            parent = new GameObject("Defenders");
        }
    }

    private void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefender;
        int defenderCost = defender.GetComponent<Defender>().sunCost;
        if (sundisplay.UseSuns(defenderCost) == SunDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundedPos, defender);
        }

    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
        return worldPos;
    }

    void SpawnDefender(Vector2 roundedPos, GameObject defender)
    {
        Quaternion zeroRot = Quaternion.identity;
        GameObject newDef = Instantiate(defender, roundedPos, Quaternion.identity) as GameObject;
        newDef.transform.parent = parent.transform;
    }
}
