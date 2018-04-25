using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    public LevelManager levelManager;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Male" || collision.transform.tag == "Female")
        {
            gameManager.isLose = true;
        }
    }


}
