using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMethods : MonoBehaviour {
    GameObject muteBtn;
    GameObject howToBtn;
    GameObject creditsBtn;

    GameObject audioSource;
    AudioSource audioComp;
    bool toggleButton;
   public bool muteToggle;

    AudioSource[] allAudioSources;

    // Use this for initialization
    void Start () {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        toggleButton = true;
        muteToggle = true;
        muteBtn = GameObject.Find("Mute");
        howToBtn = GameObject.Find("HowToPlay");
        creditsBtn = GameObject.Find("Credits");
        muteBtn.SetActive(false);
        howToBtn.SetActive(false);
        creditsBtn.SetActive(false);

        audioSource = GameObject.Find("StartMenuAudio");
        audioComp = audioSource.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OptionsClicked()
    {
        if (toggleButton)
        {
        muteBtn.SetActive(true);
        howToBtn.SetActive(true);
        creditsBtn.SetActive(true);
            toggleButton = false;
        }
        else
        {
            muteBtn.SetActive(false);
            howToBtn.SetActive(false);
            creditsBtn.SetActive(false);
            toggleButton = true;
        }
    }

    public void muteClicked()
    {
        if (muteToggle)
        {
            muteToggle = false;
            audioComp.Stop();
        }
        else
        {
            muteToggle = true;
            audioComp.Play();
        }


        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }
}
