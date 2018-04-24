using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleBall : MonoBehaviour {

    private GameObject female;

    private GameManager gameManager;

    private bool triggerWinCondition;

	void Start () {
        female = GameObject.FindGameObjectWithTag("Female");
        gameManager = GameManager.FindObjectOfType<GameManager>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Female")
        {
            gameManager.isLevelPassed = true;
            ResetToKinematic();
        }
    }

    void ResetToKinematic()
    {
        Rigidbody2D rbMale = GetComponent<Rigidbody2D>();
        rbMale.Sleep();
        Rigidbody2D rbFemale = female.GetComponent<Rigidbody2D>();
        rbFemale.Sleep();
    }




}
