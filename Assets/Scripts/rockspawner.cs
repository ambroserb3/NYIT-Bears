using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockspawner : MonoBehaviour {

    public GameObject rocks;
    public float timer;


	// Use this for initialization
	void Start () {
        timer = 3;
	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("Ybutton").GetComponent<ButtonScr>().barrierdown)  //will check if true
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            Instantiate(rocks);
            timer = 5;
        }
    }


}
