using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeAudio : MonoBehaviour {

    public AudioClip MusicClip;
    public AudioSource MusicSource;
    GameObject sphere;
    SpawnTiles spawntiles;
    // Use this for initialization
    void Start () {

        sphere = GameObject.Find("Sphere");
        spawntiles = sphere.GetComponent<SpawnTiles>();


        MusicSource.clip = MusicClip;
        if( spawntiles.muted == false)
        {
            MusicSource.Play();

        }
        else
        {
            MusicSource.Stop();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(!MusicSource.isPlaying && spawntiles.muted == false) // &&  canvasScript == false
        {
            MusicSource.Play();
        }

        if(spawntiles.muted == true)
        {
            MusicSource.Stop();
        }
            
        
		
	}
}
