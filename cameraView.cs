using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraView : MonoBehaviour {

    public GameObject ThirdCam;
    public GameObject BirdEyeCam;
    public int camMode;
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Camera"))
        {
            if(camMode == 1)
            {
                camMode = 0;
            }
            else
            {
                camMode = 1;
            }
            StartCoroutine((CamChange()));
        }
	}

    public void camClicked()
    {
        if (camMode == 1)
        {
            camMode = 0;
        }
        else
        {
            camMode = 1;
        }
        StartCoroutine((CamChange()));
    }

    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);
        if(camMode == 0)
        {
            ThirdCam.SetActive(true);
            BirdEyeCam.SetActive(false);
        }
        if (camMode == 1)
        {
            ThirdCam.SetActive(false);
            BirdEyeCam.SetActive(true);
        }
    }
}
