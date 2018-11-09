using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialPlayer : MonoBehaviour {
    
    int scoreTemp;
    public float speed = 2f;
    SpawnTiles spawnTiles;
   // GameObject player;
    // Use this for initialization
    void Start () {
        //player = GameObject.FindGameObjectWithTag("Player");
        //spawnTiles = player.GetComponent<SpawnTiles>();

    }
	
	// Update is called once per frame
	void Update () {
        //scoreTemp = spawnTiles.score;
        //if(scoreTemp >= 50)
        //{
        //    scoreTemp = spawnTiles.score - 50;
        //    Debug.Log("speed: "+ speed);
        //    speed *= 1.1f;
        //}
        
        transform.position += Vector3.forward * speed * Time.deltaTime;
        

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            double x_comp =transform.position.x + 3.3f;
            if (x_comp > 3.3)
            {
                x_comp = 3.3;
            }
            transform.position = new Vector3((float)x_comp, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            double x_comp = transform.position.x - 3.3f;
            if (x_comp < -3.3)
            {
                x_comp = -3.3;
            }
            transform.position = new Vector3((float)x_comp, transform.position.y, transform.position.z );

        }
    }
}
