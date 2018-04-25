using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool isLevelPassed = false;
    public bool isLose = false;
    private GameObject winPanel;
    private ResultDisplay resultDisplay;
    
    // Use this for initialization
	void Start () {
        FindWinPanel();
        winPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        HandleWinCondition();
        HandleLoseCondition();
	}

    void HandleWinCondition()
    {
        if (isLevelPassed)
        {
            Debug.Log("LevelPassed!");
            //make everything kinematic;
            winPanel.SetActive(true); // display win panel, which will have a win animation and music play;
            resultDisplay.DisplayWinPanel();
            isLevelPassed = false;
        }
    }

    void HandleLoseCondition()
    {
        if (isLose)
        {
            Debug.Log("You Lose!");
            winPanel.SetActive(true); // display win panel, which will have a win animation and music play;
            resultDisplay.DisplayLosePanel();
            isLose = false;
        }
    }

    void FindWinPanel()
    {
        winPanel = GameObject.Find("WinPanel");
        resultDisplay = GameObject.FindObjectOfType<ResultDisplay>();
        if (!winPanel)
        {
            Debug.LogError("Please create you win object");
        }
    }
}
