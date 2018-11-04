using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollectable : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.z+10 < player.transform.position.z)
        {
            Destroy(this.gameObject);
        }
	}

   
}
