using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds =100;


    private Slider slider;

    private AudioSource audiosource;

    private LevelManager levelManager;

    private bool isEndOfLevel = false;
    private GameObject winLabel;

    // Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        audiosource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        FindYouWin();
        winLabel.SetActive(false);
	}

    void FindYouWin()
    {
        winLabel = GameObject.Find("YouWin");
        if (!winLabel)
        {
            Debug.LogError("Please create you win object");
        }
    }
	
	// Update is called once per frame
	void Update () {
        slider.value = 1-Time.timeSinceLevelLoad / levelSeconds;
        if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel)
        {
            HandleWinCondition();
        }

    }

    void HandleWinCondition()
    {
        DestroyAllTaggedObjects();
        winLabel.SetActive(true);
        audiosource.Play();
        Invoke("LoadNextLevel", audiosource.clip.length);
        isEndOfLevel = true;
    }

    void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");

        foreach (GameObject taggedObject in taggedObjectArray)
        {
            Destroy(taggedObject);
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }


}
