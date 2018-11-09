using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour
{
    public AudioClip MusicClipGain;
    public AudioClip MusicClipLose;
    public AudioClip MusicClipColorZone;
    public AudioSource MusicSourceGain;
    public AudioSource MusicSourceLose;
    public AudioSource MusicSourceColorZone;

    Material m_Material;
    public GameObject planeTransform;
    public GameObject collectable;
    GameObject player;
    public int score;
    private int speedCount;
    initialPlayer initialplayer;

    // Use this for initialization
    void Start()
    {
        MusicSourceGain.clip = MusicClipGain;
        MusicSourceLose.clip = MusicClipLose;
        MusicSourceColorZone.clip = MusicClipColorZone;

        player = GameObject.FindGameObjectWithTag("Player");
        initialplayer = player.GetComponent<initialPlayer>();
        m_Material = GetComponent<Renderer>().material;
        InvokeRepeating("SpawnCollectable", 2.0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {



    }

    void OnTriggerEnter(Collider other)
    {
       // Debug.Log("I;m sick");

        if (other.gameObject.CompareTag("Spawner"))
        {
            //   Debug.Log("sadder");

            MusicSourceColorZone.Play();
            SpawnTile();
            m_Material.color = other.gameObject.GetComponent<Renderer>().material.color;


        }

        if (other.gameObject.CompareTag("Destroyer"))
        {
            Destroy(other.transform.parent.gameObject,1);
        }

      
    }

    void OnCollisionEnter(Collision collision)
    {

        //Debug.Log("what the heck");
        if (collision.gameObject.CompareTag("Collectable"))
        {
           
            //Debug.Log("BRACE");
            Destroy(collision.transform.gameObject);
            if (collision.gameObject.GetComponent<Renderer>().material.color == m_Material.color)
            {
                MusicSourceGain.Play();
                score += 10;
                speedCount ++;
                if (speedCount >= 5)
                {
                    speedCount =0;
                    initialplayer.speed *= 2;
                    
                    Debug.Log("speed: " + initialplayer.speed);
                }
            }
            else
            {

                MusicSourceLose.Play();
                speedCount--;
                if(speedCount < 0)
                {
                    speedCount = 0;
                }
                if (score == 1)
                {
                    score = 0;
                    
                }
                score -= score / 2;
                
            }
            Debug.Log("speedCount: " + speedCount);
            
        }
    }

    void SpawnTile(int prefabIndex = -1)
    {

        GameObject go;
        go = Instantiate(planeTransform);
        float z = transform.position.z + 10f;
        go.transform.position = new Vector3(0, 0, z);
        //Debug.Log("sad");


    }

    void SpawnCollectable()
    {
        GameObject go;
        go = Instantiate(collectable);
        int lane = Random.Range(0, 3);
        int color = Random.Range(0, 3);
        float z_compp = transform.position.z + 3;
        if (color == 0)
        {
            go.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            if (color == 1)
            {
                go.GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                if (color == 2)
                {
                    go.GetComponent<Renderer>().material.color = Color.blue;
                }

            }
        }

        if (lane == 0)
        {//right
            go.transform.position = new Vector3(3.3f, 0.41f, z_compp);
        }
        else
        {
            if (lane == 1)
            {//left
                go.transform.position = new Vector3(-3.3f, 0.41f, z_compp);
            }
            else
            {
                if (lane == 2)
                {//middle
                    go.transform.position = new Vector3(0f, 0.41f, z_compp);
                }

            }
        }

    }
}