using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour
{

    public AudioClip MusicClip;
    public AudioSource MusicSource;
    GameObject canvas;
    CanvasMethods canvasScript;
   // Use this for initialization

   void Start()
    {

        canvas = GameObject.Find("Canvas");
        canvasScript = canvas.GetComponent<CanvasMethods>();


        MusicSource.clip = MusicClip;
        MusicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!MusicSource.isPlaying && canvasScript.muteToggle == true) //not required to mute
        {
            
            MusicSource.Play();
        }



    }
}
