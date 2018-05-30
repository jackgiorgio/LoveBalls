using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

    private MusicPlayer musicPlayer;
    
    // Use this for initialization
	void Start () {
        musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            float volume = PlayerPrefsManager.GetMasterVolume();
            //musicPlayer.SetVolume(volume);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
