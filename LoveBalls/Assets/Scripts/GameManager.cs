using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool isLevelPassed = false;
    
    // Use this for initialization
	void Start () { 
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
            //winLabel.SetActive(true); display win panel, which will have a win animation and music play;
            isLevelPassed = false;
        }
    }
}
