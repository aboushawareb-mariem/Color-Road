using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorZone : MonoBehaviour {
    Material m_Material;
    Renderer rend;
    public GameObject lightZone;
   
    // Use this for initialization
    void Start()
    {
        //lightZone = GetComponent<Light>();
        
     

        m_Material = GetComponent<Renderer>().material;
        rend = GetComponent<Renderer>();
        int index = Random.Range(0, 3);
        if (index == 0)
        {
            rend.enabled = true;
            m_Material.color = Color.red;

           
           lightZone.GetComponent<Light>().color = Color.red;
        }
        else
        {
            if (index == 1)
            {
                rend.enabled = true;
                m_Material.color = Color.green;


                lightZone.GetComponent<Light>().color = Color.green;
            }
            else
            {
                if (index == 2)
                {
                    rend.enabled = true;
                    m_Material.color = Color.blue;


                    lightZone.GetComponent<Light>().color = Color.blue;
                }
               
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
