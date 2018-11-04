using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorZone : MonoBehaviour {
    Material m_Material;
    Renderer rend;
    // Use this for initialization
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        rend = GetComponent<Renderer>();
        int index = Random.Range(0, 3);
        if (index == 0)
        {
            rend.enabled = true;
            m_Material.color = Color.red;
        }
        else
        {
            if (index == 1)
            {
                rend.enabled = true;
                m_Material.color = Color.green;
            }
            else
            {
                if (index == 2)
                {
                    rend.enabled = true;
                    m_Material.color = Color.blue;
                }
               
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
