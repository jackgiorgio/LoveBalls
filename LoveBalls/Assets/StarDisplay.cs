using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDisplay : MonoBehaviour {

    public GameObject star1, star2, star3;
    public int level;

    void Start () {
        UpdateStarState();
        
	}

    void UpdateStarState()
    {
        int star = PlayerPrefsManager.GetLevelStar(level);
        Debug.Log(star);
        if (star > 0)
        { star1.SetActive(true); }
        if (star > 1)
        { star2.SetActive(true); }
        if (star > 2)
        { star3.SetActive(true); }
    }
	
}
