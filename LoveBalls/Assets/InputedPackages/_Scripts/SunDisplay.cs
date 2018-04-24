using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SunDisplay : MonoBehaviour {


    public Text sunText;
    private int suns = 100;
    public enum Status { SUCCESS, FAILURE}

    // Use this for initialization
	void Start () {
        sunText = GetComponent<Text>();
        UpdateDisplay();

    }
	
    public void AddSuns(int amount)
    {
        suns += amount;
        UpdateDisplay();
    }

    public Status UseSuns(int amount)
    {
        if (suns >= amount)
        {
            suns -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        
            return Status.FAILURE;
    }


    private void UpdateDisplay()
    {
        sunText.text = suns.ToString();
    }
}
