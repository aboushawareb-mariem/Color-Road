using UnityEngine;

using System.Collections.Generic;

using System.Collections;

public class CamFollowPlayer : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object


    private float offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position.z - player.transform.position.z;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        float f = player.transform.position.z + offset;
        transform.position = new Vector3(-0.1922977f, 2.877439f, f);
    }
}