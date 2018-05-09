using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour {

    public GameObject retryButton;
    public GameObject NextButton;
    private Animator animator;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void DisplayWinPanel(LevelPreset levelPreset, float distance)
    {
        //get screenshot of the gameplay;
        retryButton.SetActive(false);
        NextButton.SetActive(true);
        animator = GetComponent<Animator>();
        if (distance < levelPreset.threeStarsThreshold)
        {
            animator.SetTrigger("3Stars");
            return;
        }
        if (distance < levelPreset.twoStarsThreshold)
        {
            animator.SetTrigger("2Stars");
            return;
        }
        else
        {
            animator.SetTrigger("1Star");
        }
    }

    public void DisplayLosePanel()
    {
        retryButton.SetActive(true);
        NextButton.SetActive(false);
    }


}
