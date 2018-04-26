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

    public void DisplayWinPanel()
    {
        //get screenshot of the gameplay;
        retryButton.SetActive(false);
        NextButton.SetActive(true);
        animator = GetComponent<Animator>();
        animator.SetTrigger("3Stars");
    }

    public void DisplayLosePanel()
    {
        retryButton.SetActive(true);
        NextButton.SetActive(false);
    }
}
