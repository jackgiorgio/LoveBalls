using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    private GameManager gameManager;


    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Female" || collision.transform.tag == "Male")
        {
            gameManager.isLose = true;
        }
    }

}
