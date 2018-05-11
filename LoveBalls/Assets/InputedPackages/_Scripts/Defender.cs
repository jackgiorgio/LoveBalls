using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    public int sunCost = 100;
    private SunDisplay sundisplay;

    void Start()
    {
        sundisplay = GameObject.FindObjectOfType<SunDisplay>();
    }

    public void AddSuns(int amount)
    {
        sundisplay.AddSuns(amount);
    }
   

}
