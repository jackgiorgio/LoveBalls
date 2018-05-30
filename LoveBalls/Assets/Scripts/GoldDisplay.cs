using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldDisplay : MonoBehaviour {

    public GameObject star1, star2, star3;
    public ParticleSystem ps;
    public Text scoreText;
    
    // Use this for initialization
	void Start () {
        ps.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Display(int score)
    {
        scoreText.text = "+" + score.ToString();
        if (score == 75 || score == 55 || score == 30)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (score == 45 || score == 25)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        else if (score == 20)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }

    }
}
