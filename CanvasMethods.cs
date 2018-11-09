using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMethods : MonoBehaviour {
    GameObject muteBtn;
    GameObject howToBtn;
    GameObject creditsBtn;
    GameObject instructions;
    GameObject howto;
    GameObject back;
    GameObject creditsTxt;
    GameObject back1;

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
        instructions = GameObject.Find("Instructions");
        howto = GameObject.Find("howtoBack");
        back = GameObject.Find("back");
        back1 = GameObject.Find("back (1)");
        creditsTxt = GameObject.Find("CreditsTxt");

        muteBtn.SetActive(false);
        howToBtn.SetActive(false);
        creditsBtn.SetActive(false);
        instructions.SetActive(false);
        howto.SetActive(false);
        back.SetActive(false);
        back1.SetActive(false);
        creditsTxt.SetActive(false);

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

    public void howtoClicked()
    {
        
        
            howto.SetActive(true);
            instructions.SetActive(true);
            back.SetActive(true);
            
        
       
    }

    public void backClicked()
    {
        howto.SetActive(false);
        instructions.SetActive(false);
        back.SetActive(false);

    }

    public void back1Clicked()
    {
        
            howto.SetActive(false);
            creditsTxt.SetActive(false);
            back1.SetActive(false);

        
    }

    public void creditsClicked()
    {
        howto.SetActive(true); // this is the black background only
        creditsTxt.SetActive(true);
        back1.SetActive(true);
    }
}
