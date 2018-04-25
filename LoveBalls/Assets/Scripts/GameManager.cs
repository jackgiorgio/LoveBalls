using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool isLevelPassed = false;
    private GameObject winPanel;
    
    // Use this for initialization
	void Start () {
        FindWinPanel();
        winPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        HandleWinCondition();
	}

    void HandleWinCondition()
    {
        if (isLevelPassed)
        {
            Debug.Log("LevelPassed!");
            //make everything kinematic;
            winPanel.SetActive(true); // display win panel, which will have a win animation and music play;
            isLevelPassed = false;
        }
    }

    void FindWinPanel()
    {
        winPanel = GameObject.Find("WinPanel");
        if (!winPanel)
        {
            Debug.LogError("Please create you win object");
        }
    }
}
