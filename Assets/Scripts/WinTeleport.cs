using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTeleport : MonoBehaviour {

    public GameObject player;
    public float newtime;
    public GameObject wincamera;

    public float wintimer;
    public bool winTrigger;
    public string victorytime;


    public GameObject teleport;
    
    // Use this for initialization
    void Start () {
        wintimer = 2.1F;
        DontDestroyOnLoad(teleport);
	}
	
	// Update is called once per frame
	void Update () {
	    if (winTrigger)
        {
            wintimer -= Time.deltaTime;
            
            if (wintimer < 2)
            {
                wincamera.GetComponent<CameraFollow>().CameraSwitch();
            }
            if (wintimer <= 0)
            {
                newtime = player.GetComponent<Controller>().time;
                GameObject.Find("Controller").GetComponent<DataController>().SubmitNewPlayerScore(newtime);
                GameObject.Find("Controller").GetComponent<DataController>().SubmitCurrentPlayerScore(newtime);

                SceneManager.LoadScene("victory");

            }
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            winTrigger = true;
            victorytime = GameObject.Find("playerfiller").GetComponent<Controller>().niceTime;

        }
    }
}
