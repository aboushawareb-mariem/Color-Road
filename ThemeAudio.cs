using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeAudio : MonoBehaviour {

    public AudioClip MusicClip;
    public AudioSource MusicSource;
	// Use this for initialization
	void Start () {
        MusicSource.clip = MusicClip;
            MusicSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if(!MusicSource.isPlaying)
        {
            MusicSource.Play();
        }
            
        
		
	}
}
