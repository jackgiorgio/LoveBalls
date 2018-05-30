using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {


    private GameManager gameManager;


    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Female" || collider.transform.tag == "Male")
        {
            gameManager.isLose = true;
        }
    }

}
