using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spikescript : MonoBehaviour {

    public GameObject player;
    public float newtime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            newtime = player.GetComponent<Controller>().time;
            GameObject.Find("Controller").GetComponent<DataController>().SubmitNewPlayerScore(newtime);
            Destroy(player);
            SceneManager.LoadScene("gameover");
        }
    }
}
