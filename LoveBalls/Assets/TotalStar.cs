using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalStar : MonoBehaviour {

    public int level;

    // Use this for initialization
    void Start() {
        GetComponent<Text>().text = CountTotalStars().ToString();

    }

    // Update is called once per frame
    void Update() {

    }

    private int CountTotalStars() {
        int totalStar = 0;
        for (int i = 1; i < level; i++)
        {
            totalStar += PlayerPrefsManager.GetLevelStar(i);
        }
        return totalStar;
    }
}