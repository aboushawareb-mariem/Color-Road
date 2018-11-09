using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnTiles : MonoBehaviour
{
    public AudioClip MusicClipGain;
    public AudioClip MusicClipLose;
    public AudioClip MusicClipColorZone;
    public AudioSource MusicSourceGain;
    public AudioSource MusicSourceLose;
    public AudioSource MusicSourceColorZone;
    public Text scoreText;

    Material m_Material;
    public GameObject planeTransform;
    public GameObject collectable;
    GameObject player;
    public int score;
    private int speedCount;
    initialPlayer initialplayer;

    public bool muted;
    bool paused;
    bool youSuckFlag;
    GameObject pausemenu;
    GameObject gameover;

    // Use this for initialization
    void Start()
    {
        paused = false;
        muted = false;
        youSuckFlag = false;
        MusicSourceGain.clip = MusicClipGain;
        MusicSourceLose.clip = MusicClipLose;
        MusicSourceColorZone.clip = MusicClipColorZone;

        pausemenu = GameObject.Find("PauseMenu");
        gameover = GameObject.Find("gameOver");
        pausemenu.SetActive(false);
        gameover.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        initialplayer = player.GetComponent<initialPlayer>();
        m_Material = GetComponent<Renderer>().material;
        InvokeRepeating("SpawnCollectable", 2.0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

            if (paused)
        {
            Time.timeScale = 0;
            pausemenu.SetActive(true);
        }
        
        if (!paused && gameover.active == false)
        {
            Time.timeScale = 1;
            pausemenu.SetActive(false);
        }


    }

    public void muteClicked()
    {
        muted = !muted;
    }

    public void pauseClicked()
    {
        paused = true;
        pausemenu.SetActive(true);
    }

    public void resumeClicked()
    {
        paused = false;
        pausemenu.SetActive(false);
    }

    public void restartClicked(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void quitClicked()
    {
        Application.Quit();
    }

    void OnTriggerEnter(Collider other)
    {
       // Debug.Log("I;m sick");

        if (other.gameObject.CompareTag("Spawner"))
        {
            //   Debug.Log("sadder");
            if(muted == false)
            {

            MusicSourceColorZone.Play();
            }
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
                if(muted == false)
                {
                MusicSourceGain.Play();
                }
                score += 10;
                speedCount ++;
                youSuckFlag = true;
                if (speedCount >= 5)
                {
                    speedCount =0;
                    initialplayer.speed *= 2;
                    
                    Debug.Log("speed: " + initialplayer.speed);
                }
                scoreText.text = "Score: " + score;
            }
            else
            {
                
                if (muted == false)
                {
                MusicSourceLose.Play();

                }
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

                youSuckFlag = true;
                if (youSuckFlag && score == 0)
                {
                    Time.timeScale = 0;
                    gameover.SetActive(true);

                }
                scoreText.text = "Score: "+score;
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