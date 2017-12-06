using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    public float timedelay;

    // Use this for initialization
    void Start()
    {
        timedelay = 3;

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
      //  offset = transform.position - player.transform.position;
        offset = new Vector3(0,0,5);
    }

    private void Update()
    {
        timedelay -= Time.deltaTime;
        // -------------------Code for Zooming Out------------
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 125)
                Camera.main.fieldOfView += 2;
            if (Camera.main.orthographicSize <= 36)
                Camera.main.orthographicSize += 0.5F;

        }
        // ---------------Code for Zooming In------------------------
        if (Input.GetAxis("Mouse ScrollWheel") > 0 || timedelay < 0)
        {
            if (Camera.main.fieldOfView > 2)
                Camera.main.fieldOfView -= 2;
            if (Camera.main.orthographicSize >= 5)
                Camera.main.orthographicSize -= 0.5F;
        }

        // -------Code to switch camera between Perspective and Orthographic--------
        if (Input.GetKeyUp(KeyCode.B))
        {
            if (Camera.main.orthographic == true)
                Camera.main.orthographic = false;
            else
                Camera.main.orthographic = true;
        }
    }


    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (Camera.main.orthographicSize <= 5)
        {
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            transform.position = player.transform.position - offset;
        }
    }
}
