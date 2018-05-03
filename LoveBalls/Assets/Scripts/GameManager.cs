using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool isLevelPassed = false;
    public bool isLose = false;
    public bool gameStarted = false;
    private MaleBall maleBall;
    private FemaleBall femaleBall;
    private GameObject winPanel;
    private ResultDisplay resultDisplay;
    
    // Use this for initialization
	void Start () {
        FindWinPanel();
        maleBall = GameObject.FindObjectOfType<MaleBall>();
        maleBall.transform.GetComponent<Rigidbody2D>().isKinematic = true;
        femaleBall = GameObject.FindObjectOfType<FemaleBall>();
        femaleBall.transform.GetComponent<Rigidbody2D>().isKinematic = true;
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
            maleBall.ChangeFace(MaleBall.Face.smile);
            femaleBall.ChangeFace(FemaleBall.Face.smile);
            winPanel.SetActive(true); // display win panel, which will have a win animation and music play;
            resultDisplay.DisplayWinPanel();
            isLevelPassed = false;
            UnblockedLevelIfNeeded();
        }
    }

    void HandleLoseCondition()
    {
        if (isLose)
        {
            Debug.Log("You Lose!");
            maleBall.ChangeFace(MaleBall.Face.cry);
            femaleBall.ChangeFace(FemaleBall.Face.cry);
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

    public void SetFreeBalls()
    {
        maleBall.transform.GetComponent<Rigidbody2D>().isKinematic = false;
        femaleBall.transform.GetComponent<Rigidbody2D>().isKinematic = false;

    }

    void UnblockedLevelIfNeeded()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 4;
        Debug.Log("current level is Level " + currentLevel +", " + PlayerPrefsManager.IsLevelUnblocked(currentLevel+1));
        if (!PlayerPrefsManager.IsLevelUnblocked(currentLevel))
        {
            PlayerPrefsManager.UnblockLevel(currentLevel + 1);
        }
    }


}
