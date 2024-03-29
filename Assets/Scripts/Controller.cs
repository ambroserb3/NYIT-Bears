﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public bool specialkeyheld;
    public bool keyheld;

    public float lives;

    public Text lifeCount;
    public float time;
    public Text Timeee;
    public Text Keys;
    public float newtime;

    public GameObject player;

    public string niceTime;
    private bool invincible;
    public float invinciblecountdown;

    public int lockPos = 0;
    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();

        lives = 3;

        invinciblecountdown = 1;

        time = 0;

        DontDestroyOnLoad(player);
    }

    void Update()
    {
        if (GameObject.Find("Teleporter T").GetComponent<WinTeleport>().winTrigger == false)
        { 
            time += Time.deltaTime;
        }
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        if (lives == 0)
        {
            GameObject.Find("Teleporter T").GetComponent<WinTeleport>().victorytime = GameObject.Find("playerfiller").GetComponent<Controller>().niceTime;
            newtime = player.GetComponent<Controller>().time;
            GameObject.Find("Controller").GetComponent<DataController>().SubmitCurrentPlayerScore(newtime);
            PlayerPrefs.SetString("Record Time", niceTime);
            SceneManager.LoadScene("gameover");   
        }

        lifeCount.text = "Lives Remaining: " + lives;
        Timeee.text = "Time: " + niceTime;

        if (specialkeyheld == true)
        {
            Keys.text = "You have a key";
        }
        else
        {
            Keys.text = "No keys";
        }

        if (invinciblecountdown < 0)
        {
            invincible = false; 
        }

        if (time > 6.5F)
        {
            //rb2d.velocity = rb2d.velocity.normalized * 3F;
        }
        player.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        if (time > 3)
        {
            rb2d.AddForce(movement * 2);
        }
    }


    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Key")
        {
            Destroy(c.gameObject);
            keyheld = true;
        }

        if (c.gameObject.tag == "SKey")
        {
            Destroy(c.gameObject);
            specialkeyheld = true;
        }

        if (c.gameObject.tag == "rock" && invincible == false)
        {
            lives = lives - 1;
            invincible = true;
            invinciblecountdown = 3;
            invinciblecountdown -= Time.deltaTime;
        }
    }

}
