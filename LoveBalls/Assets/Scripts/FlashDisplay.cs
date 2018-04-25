using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlashDisplay : MonoBehaviour {

    public GameObject thingToBeFlash;

    // Use this for initialization
    void Start() {
        InvokeRepeating("FlashTheObject", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void FlashTheObject()
    {
        if (thingToBeFlash.activeInHierarchy)
        {
            thingToBeFlash.SetActive(false);
        }
        else
        {
            thingToBeFlash.SetActive(true);
        }
    }
}
